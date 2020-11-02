using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManger1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WriteXML();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public class Book
    {
        public string title;
    }

    public  void WriteXML()
    {
        Book overview = new Book();
        overview.title = "Serialization Overview";
        System.Xml.Serialization.XmlSerializer writer =
            new System.Xml.Serialization.XmlSerializer(typeof(Book));

        Debug.Log(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        Debug.Log(Environment.UserDomainName);
        Debug.Log(Environment.ProcessorCount);
        Debug.Log(Environment.WorkingSet);
        Debug.Log(Environment.Version);
        Debug.Log(Environment.OSVersion);
        Debug.Log(Environment.GetLogicalDrives());
        Debug.Log(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
        // var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
        // System.IO.FileStream file = System.IO.File.Create(path);

        // writer.Serialize(file, overview);
        // file.Close();
    }
}
