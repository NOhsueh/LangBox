﻿using System.Collections.Generic;
using System.IO;
using LangBox.Operaters.Managers;

namespace LangBox.Operaters
{
    internal class ManageHelper
    {
        private Dictionary<string, bool> langMap;
        private string localPath;
        private const string filesPath = "LangBox Files";
        private const string C_CPPFilesName = "c_cpp";
        private const string PythonFilesName = "python";
        private const string JavaFilesName = "java";
        private const string CSharpFilesName = "csharp";
        /// <summary>
        /// 显示进度委托
        /// </summary>
        /// <param name="percentProgress">进度信息字符串</param>
        public delegate void OnProgressChangeHandler(int percentProgress);
        /// <summary>
        /// 当进度变化时的事件操作
        /// </summary>
        public event OnProgressChangeHandler OnProgressChangeEvent;

        public ManageHelper(Dictionary<string, bool> langMap, string localPath)
        {
            this.langMap = langMap;
            this.localPath = localPath;
        }

        public void Start()
        {
            string filesPath = Path.Combine(localPath, ManageHelper.filesPath);
            if (!Directory.Exists(filesPath))
            {
                Directory.CreateDirectory(filesPath);
            }

            C_CPPManager.Start(Path.Combine(filesPath, C_CPPFilesName), langMap["C_CPP"]);
            UpdateProgress(0);

            PythonManager.Start(Path.Combine(filesPath, PythonFilesName), langMap["Python"]);
            UpdateProgress(0);

            JavaManager.Start(Path.Combine(filesPath, JavaFilesName), langMap["Java"]);
            UpdateProgress(0);

            CSharpManager.Start(Path.Combine(filesPath, CSharpFilesName), langMap["CSharp"]);
            UpdateProgress(0);
        }

        public void UpdateProgress(int percentProgress)
        {
            OnProgressChangeEvent(percentProgress);
        }
    }
}