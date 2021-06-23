using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DWLTRemovePRO_App
{
    class Remover
    {
        private static string jsonFile = "unity_directories.json";
        private static string dwltFolderName = @"\Library";

        public Dictionary<string, FileSystemWatcher> UnityDirectories = new Dictionary<string, FileSystemWatcher>();
        private bool isStarted = false;

        private Form1 form;

        public Remover(Form1 form)
        {
            this.form = form;
        }

        public void LoadDirectories()
        {
            if (File.Exists(jsonFile))
            {
                string directoriesJson = File.ReadAllText(jsonFile);
                List<string> directoryNames = new List<string>();
                directoryNames = JsonSerializer.Deserialize<List<string>>(directoriesJson);

                foreach (string name in directoryNames)
                {
                    if (CheckDirectory(name))
                    {
                        AddLog("Adding unity directory " + name);
                        UnityDirectories[name] = null;
                    }
                    else
                    {
                        AddLog("Cannot load " + name + "\nAre you sure this is still a Unity Directory?");
                    }
                }
            }
            else
            {
                AddLog("JSON file does not exist.");
            }
        }

        private bool CheckDirectory(string directory)
        {
            return Directory.Exists(directory + dwltFolderName);
        }

        public void SaveDirectories()
        {
            string directoriesJson = JsonSerializer.Serialize(UnityDirectories.Keys.ToList());
            File.WriteAllText(jsonFile, directoriesJson);
            AddLog("Save directories to " + jsonFile);
        }

        public bool AddDirectory(string dir)
        {
            bool added = false;
            AddLog("Adding new Directory: " + dir);

            if (!UnityDirectories.ContainsKey(dir))
            {
                if (isStarted)
                {
                    UnityDirectories.Add(dir, StartWatching(dir));
                }
                else
                {
                    UnityDirectories.Add(dir, null);
                }
                SaveDirectories();
                added = true;
            }
            else
            {
                AddLog("Directory already registered");
            }

            return added;
        }

        public bool RemoveDirectory(string dir)
        {
            AddLog("Removing directory:" + dir);

            bool removed = false;

            if (UnityDirectories.ContainsKey(dir))
            {
                UnityDirectories[dir]?.Dispose();
                UnityDirectories.Remove(dir);
                SaveDirectories();
                removed = true;
            }
            else
            {
                AddLog("Directory does not exist : Should not happen.");
            }

            return removed;
        }

        public void StartWatching()
        {
            if (!isStarted)
            {
                isStarted = true;

                foreach (var item in UnityDirectories.Keys.ToArray())
                {
                    if (UnityDirectories[item] == null)
                    {
                        UnityDirectories[item] = StartWatching(item);
                        AddLog("Starting to watch " + item);
                    }
                }
            }
            else
            {
                AddLog("Already watching : Should not happen.");
            }
        }

        public void StopWatching()
        {
            if (isStarted)
            {
                isStarted = false;
                foreach (var item in UnityDirectories.Keys.ToArray())
                {
                    UnityDirectories[item]?.Dispose();
                    UnityDirectories[item] = null;
                }
            }
        }

        private void DeleteExisting(string path)
        {
            foreach (var file in Directory.EnumerateFiles(path + dwltFolderName).ToArray())
            {
                if (Path.GetExtension(file) == ".dwlt")
                {
                    DeleteDWLT(file);
                }
            }
        }

        private FileSystemWatcher StartWatching(string path)
        {
            DeleteExisting(path);

            FileSystemWatcher watcher = null;
            try
            {
                watcher = new FileSystemWatcher(path + dwltFolderName);

                watcher.NotifyFilter = NotifyFilters.FileName;
                watcher.Created += OnCreated;
                watcher.Filter = "*.dwlt";
                watcher.EnableRaisingEvents = true;
            }
            catch (Exception e)
            {
                AddLog("Something went wrong when creating Watcher!\n"+ e.Message);
            }

            return watcher;
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            DeleteDWLT(e.FullPath);
        }

        private void DeleteDWLT(string path)
        {
            Task.Run(() =>
            {
                while (IsFileLocked(path))
                {
                    AddLog("File locked  by another process. Waiting.");
                    Thread.Sleep(3000);
                }

                try
                {
                    File.Delete(path);
                    AddLog("Deleted " + path + "!! Not on my watch, son!");
                }
                catch(Exception e)
                {
                    AddLog("Failed to delete " + path + ".\n" + e.Message);
                }
            });
        }

        private void AddLog(string log)
        {
            form.AddLog(log);
        }

        protected virtual bool IsFileLocked(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        stream.Close();
                    }
                }
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }
    }
}
