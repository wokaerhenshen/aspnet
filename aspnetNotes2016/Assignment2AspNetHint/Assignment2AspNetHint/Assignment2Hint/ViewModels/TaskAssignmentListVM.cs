using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2Hint.ViewModels {
    public class TaskAssignmentListVM {

        // Note these are public and get/set are required.
        [Required]
        public List<TaskAssignmentVM> taskAssignmentVM { get; set; }
        public TaskAssignmentListVM() { 
        }
    }
}