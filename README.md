# DataImporter
Pulls data from excel, csv or any delimited text, json, or a regex and parses it into a database.  It is a builder, command line app and a reference. Import settings are saved in a config file.

It's a library, it's a command line executable, it's a windows app. It's also complicated to use, I do what I can.

windows builder app:
![image](https://user-images.githubusercontent.com/5985484/41800242-bcf2c948-7642-11e8-9e33-f7d59b3d01a9.png)

Save a config file then call it like :
![image](https://user-images.githubusercontent.com/5985484/41800366-3b495064-7643-11e8-9e42-4d301303548a.png)

Or call it with coder like:
```C#
                String filename = Server.MapPath(".") + "/" + testul.uploadPath + "/" + afilename;
                
                    var di = new DataImporter.DataImporter();
                    di.readConfigs(Server.MapPath("Import.config"));
                    di.fileName = filename;
                    
                    //Set the connection string Using the one in web.config
                    di.connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    di.UploadTableFilename();
                    
                    //Save the reuslts to a single string. Will give inserted, updated and deleted record count.
                    var results = di.statusList.Replace("\n", "<br/>");
                    results += di.errorList.Replace("\n", "<br/>");
```
