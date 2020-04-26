﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class Following
    {
        //composite key
        [Key]
        [Column(Order = 1)]
        public  string FollowerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FolloweeId { get; set; }

        //nav properties
        public ApplicationUser Follower { get; set; }
        public ApplicationUser Followee { get; set; }
    }
}