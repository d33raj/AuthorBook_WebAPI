﻿using AuthorWebApi.Models;

namespace AuthorWebApi.DTO
{
    public class AuthorDetailsDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string NameOfAuthor { get; set; }
    }
}
