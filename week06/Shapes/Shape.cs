using System;

namespace Shapes
{
   public class Shape
    {
        private string _Colored;
        public Shape(string colored)
            {
                _Colored = colored;
            }
            public string GetColored()
            {
                return _Colored;
            }
            public void SetColored(string colored)
            {
                _Colored = colored;
            }
            public virtual double GetArea()
            {
                return 0;
            }   
        
    }
}
