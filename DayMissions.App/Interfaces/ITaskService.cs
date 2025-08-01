﻿using DayMissions.App.Dtos.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.App.Interfaces
{
    public interface ITaskService
    {
        public GetTask GetTask(int id);
        public IEnumerable<GetTask> GetActive(string UserId);
        public GetTask AddTask(AddTask task,string UserId);
        public GetTask UpdateActive(int id);
        public GetTask UpdateTask(int id, UpdateTask task);
        public void DeleteTask(int id);
    }

}
