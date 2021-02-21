using System;
using System.Collections.Generic;
using System.Text;

namespace BlogForm.Models
{
    public class BreedGroupVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Image { get; set; }

        public int? ParentId { get; set; }

        public List<BreedGroupVM> Children { get; set; }
    }
}
