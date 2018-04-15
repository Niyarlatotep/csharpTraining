using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            if (args.Length < 4)
            {
                Console.Write("dataType=[group:contacts] count=[line numbers] fileName=[path to file] format=[xm:json]");
                return;
            }

            try
            {
                count = Convert.ToInt32(args[1]);
            }
            catch
            {
                Console.Write("Count is not a number");
                return;
            }            
                        
            using (StreamWriter writer = new StreamWriter(args[2]))            
            {
                string format = args[3];
                string dataType = args[0];
                dynamic dataObjects = null;

                if (dataType == "group")
                {
                    dataObjects = new List<GroupData>();
                    for (int i = 0; i < count; i++)
                    {
                        dataObjects.Add(new GroupData(TestBase.GenerateRandomString(10))
                        {
                            Header = TestBase.GenerateRandomString(100),
                            Footer = TestBase.GenerateRandomString(100)
                        });
                    }
                }
                else if (dataType == "contacts")
                {
                    dataObjects = new List<ContactData>();
                    for (int i = 0; i < count; i++)
                    {
                        dataObjects.Add(new ContactData
                            (
                                TestBase.GenerateRandomString(10),
                                TestBase.GenerateRandomString(100)
                            ));
                    }
                }
                else
                {
                    Console.Write("Unrecognized type " + dataType);
                    return;
                }
                               

                if (format == "xml")
                {
                    writeGroupsToXmlFile(dataObjects, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(dataObjects, writer);
                }
                else
                {
                    Console.Write("Unrecognized format " + format);
                    return;
                }
            }    
        }
        static void writeGroupsToXmlFile<T>(List<T> dataObjects, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<T>)).Serialize(writer, dataObjects);
        }

        static void writeGroupsToJsonFile<T>(List<T> dataObjects, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(dataObjects, Formatting.Indented)); 
        }
    }
}
