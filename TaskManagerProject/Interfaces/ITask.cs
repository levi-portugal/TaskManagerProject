using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagerProject.Interfaces
{
    internal interface ITask
    {
        public void CreateTask();
        public void EditTask();
        public void DeleteTask();
    }
}
