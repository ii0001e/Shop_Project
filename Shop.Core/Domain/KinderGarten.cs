﻿namespace Shop.Core.Domain
{
    public class KinderGarten
    {

        public Guid? Id { get; set; }
        public string GroupName { get; set; }

        public int ChildrenCount { get; set; }

        public string KindergartenName { get; set; }

        public string Teacher { get; set; }



        //database

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
