using Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Plugin.Engine
{
    /// <summary>
    /// Plug-in'lerimizi bulup instance'larını türetip geyire dönderecek olan class'ımız.
    /// </summary>
    public class PluginEngine : MarshalByRefObject
    {
        public List<ICommand> LoadPlugInCommands()
        {
            // Plug-in'lerimizin instance'larını ekleyeceğimiz listemiz
            var commandList = new List<ICommand>();
            // Plug-in'lerimizi bulmak için tarıyacağımız ana PlugIns path'imiz.
            string basePath = AppDomain.CurrentDomain.BaseDirectory + "PlugIns";
            // GetFiles metotuna yazdığımız "*.dll" patterni ile
            //ilgili path'imizdeki assembly'lerimizi buluyoruz
            foreach (var filePath in Directory.GetFiles(basePath, "*.dll")) 
            {
                // Reflection namespace'si altındaki Assembly sınıfı ile ilgili assembly'imizi yüklüyoruz
                var loadedAssembly = Assembly.LoadFile(filePath);
                // ICommand'dan inherit alan nesneleri buluyoruz
                var calculationTypes = loadedAssembly.GetTypes().Where(t => typeof(ICommand).IsAssignableFrom(t)); 

                foreach (var calculationType in calculationTypes)
                {
                    // Instance'sini üretiyoruz
                    var cmd = Activator.CreateInstance(calculationType);
                    // Ürettiğimiz instance'ımızı hazırlamış olduğumuz bizim için serialize 
                    //hale getirecek olan Communicator ile sarmalıyor
                    //ve commandList'imize ekliyoruz
                    commandList.Add(new Communicator(cmd as ICommand)); 
                }
            }
            return commandList;
        }
    }
}
