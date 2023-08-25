﻿using System.Text.Json.Serialization;

namespace Lift.Buddy.Core.Models
{
    public class UserData
    {
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("surname")]
        public string Surname { get; set; } = string.Empty;
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
    }
}