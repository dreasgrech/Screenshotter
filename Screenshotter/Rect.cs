﻿
namespace Screenshotter
{
    using System.Drawing;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        private int _Left;
        private int _Top;
        private int _Right;
        private int _Bottom;

        public Rect(Rect rectangle) : this(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom) { }

        public Rect(int left, int top, int right, int bottom)
        {
            _Left = left;
            _Top = top;
            _Right = right;
            _Bottom = bottom;
        }

        public int X
        {
            get { return _Left; }
            set { _Left = value; }
        }
        public int Y
        {
            get { return _Top; }
            set { _Top = value; }
        }
        public int Left
        {
            get { return _Left; }
            set { _Left = value; }
        }
        public int Top
        {
            get { return _Top; }
            set { _Top = value; }
        }
        public int Right
        {
            get { return _Right; }
            set { _Right = value; }
        }
        public int Bottom
        {
            get { return _Bottom; }
            set { _Bottom = value; }
        }
        public int Height
        {
            get { return _Bottom - _Top; }
            set { _Bottom = value + _Top; }
        }
        public int Width
        {
            get { return _Right - _Left; }
            set { _Right = value + _Left; }
        }
        public Point Location
        {
            get { return new Point(Left, Top); }
            set
            {
                _Left = value.X;
                _Top = value.Y;
            }
        }
        public Size Size
        {
            get { return new Size(Width, Height); }
            set
            {
                _Right = value.Width + _Left;
                _Bottom = value.Height + _Top;
            }
        }

        public static implicit operator Rectangle(Rect rectangle)
        {
            return new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height);
        }
        public static implicit operator Rect(Rectangle rectangle)
        {
            return new Rect(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
        }
        public static bool operator ==(Rect rectangle1, Rect rectangle2)
        {
            return rectangle1.Equals(rectangle2);
        }
        public static bool operator !=(Rect rectangle1, Rect rectangle2)
        {
            return !rectangle1.Equals(rectangle2);
        }

        public override string ToString()
        {
            return "{Left: " + _Left + "; " + "Top: " + _Top + "; Right: " + _Right + "; Bottom: " + _Bottom + "}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public bool Equals(Rect rectangle)
        {
            return rectangle.Left == _Left && rectangle.Top == _Top && rectangle.Right == _Right && rectangle.Bottom == _Bottom;
        }

        public override bool Equals(object Object)
        {
            if (Object is Rect)
            {
                return Equals((Rect)Object);
            }

            if (Object is Rectangle)
            {
                return Equals(new Rect((Rectangle)Object));
            }

            return false;
        }
    }
}
