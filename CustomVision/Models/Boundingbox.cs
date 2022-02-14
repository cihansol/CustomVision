using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;


namespace CustomVision.Models
{
    public class Boundingbox
    {
        public float Height { get; set; }
        public float Left { get; set; }
        public float Top { get; set; }
        public float Width { get; set; }

        public RectangleF GetAsRectangle()
        {
            return new RectangleF(Left, Top, Width, Height);
        }

        public RectangleF TransformToImageBounds(float width, float height)
        {
            //https://stackoverflow.com/a/50799050
            var rect = new RectangleF(Left * width, Top * height, Width * width, Height * height);
            return rect;
        }

    }
}
