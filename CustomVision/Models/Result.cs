using System;
using System.Collections.Generic;

using Newtonsoft.Json;


namespace CustomVision.Models
{
    public class Result
    {
        public DateTime Created { get; set; }
        public string Id { get; set; }
        public string Iteration { get; set; }
        public Prediction[] Predictions { get; set; }
        public string Project { get; set; }
    }
}
