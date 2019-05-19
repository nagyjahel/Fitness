using System;

namespace Fitness.Models
{
    public class ErrorViewModel
    {
        public string Id { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(Id);
    }
}