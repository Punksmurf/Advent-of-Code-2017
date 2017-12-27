using System;
namespace Day19
{
    public class Renderer
    {
        Tubes _tubes;
        bool _debug = false;

        public Renderer(Tubes tubes)
        {
            _tubes = tubes;
        }

        public void Render(int preferedCenterX, int preferedCenterY) {
            var displayWidth = Console.BufferWidth;
            var displayHeight = Console.BufferHeight - 1; //prevent scrolling on last line

            var left = preferedCenterX - displayWidth / 2;

            var top = preferedCenterY - displayHeight / 2;

            left = Math.Max(0, Math.Min(left, _tubes.Width - displayWidth));
            var centerX = preferedCenterX - left;


            /*
             * tubes width: 100
             * display width: 50
             * center: 10
             * 
             * left = 10 - (25) = -15
             * left = 0
             * => center = 10
             * 
             * 
             * center: 40
             * left = 40 - (25) = 15
             * left = 15
             * => center = 40-15
             * 
             * 
             */


            top = Math.Max(0, Math.Min(top, _tubes.Height - displayHeight));
            var centerY = preferedCenterY - top;

            var window = _tubes.GetWindow(top, left, displayWidth, displayHeight);

            Console.Clear();

            if (_debug)
            {
                Console.WriteLine("dw: " + displayWidth);
                Console.WriteLine("dw: " + displayHeight);
                Console.WriteLine("tw: " + _tubes.Width);
                Console.WriteLine("th: " + _tubes.Height);
                Console.WriteLine("x: " + preferedCenterX);
                Console.WriteLine("y: " + preferedCenterY);
                Console.WriteLine("l: " + left);

                Console.WriteLine("t: " + top);
                Console.WriteLine("wh: " + window.Length);
                Console.WriteLine("ww: " + window[0].Length);
                Console.WriteLine(window[0]);
                Console.WriteLine(window[1]);
                Console.WriteLine(window[2]);
                Console.WriteLine(window[3]);
                Console.WriteLine(window[4]);
                Console.WriteLine(window[5]);
                Console.WriteLine(window[6]);
                Console.WriteLine(window[7]);
                Console.WriteLine(window[8]);
                Console.WriteLine(window[9]);


            }
            else
            {
                for (var row = 0; row < Math.Min(displayHeight, window.Length); row++)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = row;
                    Console.Write(String.Concat(window[row]));
                }

                Console.CursorLeft = centerX;
                Console.CursorTop = centerY;
                Console.Write('*');
            }


        }
    }
}
