using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WPFLibrary
{
    [System.Serializable]
    public class ikkoClass
    {
        public KeywordsClass MainKeywords;
        public ikkoClass()
        {
            MainKeywords = new KeywordsClass();
        }

        public KeywordClass AddNewKeyword(string KeywordName)
        {
            KeywordClass newKeyword = new KeywordClass();
            newKeyword.Keyword = KeywordName;
            newKeyword.Notes = "Note";

            MainKeywords.AddNewKeyword(newKeyword);
            return newKeyword;
        }

        public void ReadFile()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Keywords.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(ikkoClass));

            StreamReader reader = new StreamReader(path);

            MainKeywords = ((ikkoClass)serializer.Deserialize(reader)).MainKeywords;
            reader.Close();
        }

        public void WriteToFile()
        {
            XmlSerializer writer = new XmlSerializer(typeof(ikkoClass));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Keywords.xml";
            File.Delete(path);
            FileStream file = File.Create(path);

            writer.Serialize(file, this);
            file.Close();
        }
    }

    [System.Serializable]
    public class KeywordsClass
    {
        public List<KeywordClass> Keywords;
        public KeywordsClass()
        {
            Keywords = new List<KeywordClass>();
        }

        public void AddNewKeyword(KeywordClass newKeyword)
        {
            Keywords.Add(newKeyword);
        }
    }

    [System.Serializable]
    public class KeywordClass
    {
        public string Keyword { get; set; }
        public string Notes { get; set; }
        public string Pattern { get; set; }
        public List<KeywordParameter> KeywordParameters { get; set; }
        public KeywordClass()
        {
            KeywordParameters = new List<KeywordParameter>();
        }

    }
    [System.Serializable]
    public class KeywordParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }   
    }

}

//select single * from table as t1 inner join table2 as t2 on t1~c1 eq t2~c1 where t1~c1 eq w1 into (?inline) structure.
