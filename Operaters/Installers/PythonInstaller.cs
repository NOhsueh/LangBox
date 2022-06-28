﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangBox.Operaters.Installers
{
    internal class PythonInstaller
    {
        private string operation;

        /// <summary>
        /// 显示进度委托
        /// </summary>
        /// <param name="progressText">进度信息字符串</param>
        public delegate void OnProgressChangeHandler(String progressText);

        /// <summary>
        /// 当进度变化时的事件操作
        /// </summary>
        public event OnProgressChangeHandler OnProgressChangeEvent;

        public void Start()
        {
            ChangeProgress("配置Python环境");
        }

        private void ChangeProgress(string newOperation)
        {
            operation = newOperation;
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            OnProgressChangeEvent(operation);
        }
    }
}