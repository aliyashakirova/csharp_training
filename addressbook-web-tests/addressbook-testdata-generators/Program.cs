using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_testdata_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string format = args[2];
            string datatype = args[3];

            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i< count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100)
                });
            }

            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                {
                    Address = TestBase.GenerateRandomString(100),
                    Company = TestBase.GenerateRandomString(100)
                });
            }

            if (format == "excel")
            {
                if (datatype == "g")
                {
                    WriteGroupsToExcelFile(groups, filename);
                }
                else if (datatype == "c")
                {
                    WriteContactsToExcelFile(contacts, filename);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized datatype " + datatype);
                }
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename);
                if (format == "csv")
                {

                    if (datatype == "g")
                    {
                        WriteGroupsToCsvFile(groups, writer);
                    }
                    else if (datatype == "c")
                    {
                        WriteContactsToCsvFile(contacts, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized datatype " + datatype);
                    }
                    //WriteGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    if (datatype == "g")
                    {
                        WriteGroupsToXmlFile(groups, writer);
                    }
                    else if (datatype == "c")
                    {
                        WriteContactsToXmlFile(contacts, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized datatype " + datatype);
                    }
                    //WriteGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    if (datatype == "g")
                    {
                        WriteGroupsToJsonFile(groups, writer);
                    }
                    else if (datatype == "c")
                    {
                        WriteContactsToJsonFile(contacts, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized datatype " + datatype);
                    }
                    //WriteGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
                writer.Close();
            }
            
        }

        static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }


        static void WriteContactsToExcelFile(List<ContactData> contacts, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (ContactData contact in contacts)
            {
                sheet.Cells[row, 1] = contact.Firstname;
                sheet.Cells[row, 2] = contact.Lastname;
                sheet.Cells[row, 3] = contact.Address;
                sheet.Cells[row, 4] = contact.Company;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }
        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                        group.Name, group.Header, group.Footer));
            }
        }
        static void WriteContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3}",
                        contact.Firstname, contact.Lastname, contact.Address, contact.Company));
            }
        }
        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer,groups);
        }
        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
