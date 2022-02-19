using System;

namespace UnityLesson_CSharp_LiscovExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    class Rectangle
    {
        public float width;
        public float height;

        virtual public void SetWidth(float value)
        {
            width = value;
        }
        virtual public void SetHeight(float value)
        {
            height = value;
        }
    }
    class Square : Rectangle
    {
        public override void SetWidth(float value)
        {
            base.SetWidth(value);
            height = value;
        }
        public override void SetHeight(float value)
        {
            base.SetHeight(value);
            width = value;
        }
    }
}
