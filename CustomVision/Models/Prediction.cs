using System;
using System.Collections.Generic;

using Newtonsoft.Json;


namespace CustomVision.Models
{
    public class Prediction
    {
        public Boundingbox BoundingBox { get; set; }
        public float Probability { get; set; }
        public int TagId { get; set; }
        public string TagName { get; set; }
    }
}
