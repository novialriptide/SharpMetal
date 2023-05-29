using System.Text.RegularExpressions;

namespace SharpMetal.Generator
{
    public class HeaderInfo
    {
        public List<EnumInstance> EnumInstances = new();
        public List<StructInstance> StructInstances = new();

        public HeaderInfo(string filePath)
        {
            using (StreamReader sr = new StreamReader(File.OpenRead(filePath)))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();

                    if (line.StartsWith("class") || line.StartsWith("struct"))
                    {
                        if (!line.Contains(";"))
                        {
                            var structInfo = line.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                            var structName = "MTL" + structInfo[1];

                            StructInstances.Add(new StructInstance(structName));

                            bool structEnded = false;

                            while (!structEnded)
                            {
                                if (sr.ReadLine().Contains("}"))
                                {
                                    structEnded = true;
                                }
                            }
                        }
                    }

                    if (line.StartsWith("_MTL_ENUM"))
                    {
                        line = line.Replace("_MTL_ENUM(", "");
                        line = line.Replace(") {", "");
                        var info = line.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                        var type = info[0];
                        var ogName = info[1];

                        var name = "MTL" + ogName;

                        var values = new Dictionary<string, string>();
                        var finishedEnumerating = false;

                        while (!finishedEnumerating)
                        {
                            var nextLine = sr.ReadLine();
                            if (nextLine == "};")
                            {
                                finishedEnumerating = true;
                                continue;
                            }

                            nextLine = nextLine.Trim().Replace(",", "");
                            var valueInfo = nextLine.Split("=", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

                            // Remove original name from each enum's name IOCompressionMethodZlib -> Zlib
                            var cleanedValueName = valueInfo[0].Replace(ogName, "");
                            var cleanedValueValue = valueInfo[1];

                            // Sometimes the first character of en enum value's name will be a number after we
                            // remove the full name. In that case, add back the last part of the enum's name
                            if (Char.IsDigit(cleanedValueName[0]))
                            {
                                Regex regex = new Regex(
                                    @"(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])"
                                );
                                cleanedValueName = regex.Replace(name, " ").Split(" ").Last() + cleanedValueName;
                            }

                            cleanedValueName = cleanedValueName.Replace("_", "");

                            // Happens in one place in MTLDevice
                            if (cleanedValueValue == "NS::UIntegerMax")
                            {
                                cleanedValueValue = "UInt64.MaxValue";
                            }

                            values.Add(cleanedValueName, cleanedValueValue);
                        }

                        switch (type)
                        {
                            case "NS::UInteger":
                                EnumInstances.Add(new EnumInstance(typeof(ulong), name, values));
                                break;
                            case "NS::Integer":
                                EnumInstances.Add(new EnumInstance(typeof(long), name, values));
                                break;
                            case "uint8_t":
                                EnumInstances.Add(new EnumInstance(typeof(byte), name, values));
                                break;
                        }
                    }

                    // These contain all the selectors we need
                    if (line.StartsWith("_MTL_INLINE"))
                    {
                        string pattern = @"\s(?![^()]*\))";
                        string[] result = Regex.Split(line, pattern);
                        var parentStructName = "";

                        if (result.Count() == 2)
                        {
                            parentStructName = "MTL" + result[1].Split("::")[1];
                        }
                        else
                        {
                            parentStructName = "MTL" + result[2].Split("::")[1];
                        }

                        sr.ReadLine();
                        var selector = sr.ReadLine();
                        sr.ReadLine();

                        string lookingFor = "_MTL_PRIVATE_SEL(";
                        int index = selector.IndexOf(lookingFor);

                        if (index != -1)
                        {
                            // Only get stuff in the brackets of the _MTL_PRIVATE_SEL
                            selector = selector.Substring(index + lookingFor.Length);
                            selector = selector.Substring(0, selector.IndexOf(")"));
                            selector = selector.Replace("_", ":");
                            var parentIndex = StructInstances.FindIndex(x => x.Name == parentStructName);

                            if (parentIndex != -1)
                            {
                                StructInstances[parentIndex].AddSelector(new SelectorInstance(selector));
                            }
                            else
                            {
                                Console.WriteLine($"Orphaned Selector! Looking for {parentStructName}");
                            }
                        }
                    }
                }
            }
        }
    }

    public class StructInstance
    {
        public string Name;
        public List<SelectorInstance> SelectorInstances;

        public StructInstance(string name)
        {
            Name = name;
            SelectorInstances = new();
        }

        public void AddSelector(SelectorInstance selectorInstance)
        {
            SelectorInstances.Add(selectorInstance);
        }
    }

    public class EnumInstance
    {
        public Type Type;
        public string Name;
        public Dictionary<string, string> Values;

        public EnumInstance(Type type, string name, Dictionary<string, string> values)
        {
            Type = type;
            Name = name;
            Values = values;
        }
    }

    public class SelectorInstance
    {
        public string Name;
        public string Selector;

        public SelectorInstance(string selector)
        {
            Name = BuildName(selector);
            Selector = selector;
        }

        static string BuildName(string input)
        {
            string[] parts = input.Split(':');

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Length > 0)
                {
                    if (i < parts.Length - 1 && parts[i + 1].Length > 0)
                    {
                        parts[i + 1] = char.ToUpper(parts[i + 1][0]) + parts[i + 1].Substring(1);
                    }
                    parts[i] = parts[i].Replace(":", "");
                }
            }

            return "sel_" + string.Join("", parts);
        }
    }
}