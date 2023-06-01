﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Data.Models
{
	public class Category
	{
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Category Name Not Empty")]
        [StringLength(20,ErrorMessage ="Please only 4-20 length characters", MinimumLength =4)]
		public string CategoryName { get; set; }
        //[Required(ErrorMessage = "Category Description Not Empty")]
        public string CategoryDescription { get; set; }
        public bool Status { get; set; }
        public List<Food> Foods { get; set;}
	}
}
