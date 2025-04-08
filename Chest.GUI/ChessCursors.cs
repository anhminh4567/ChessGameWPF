using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chest.GUI
{
    public static class ChessCursors
    {
        private static Cursor LoadCursor(string filePath)
        {
            Stream stream = Application.GetResourceStream(new Uri(filePath, UriKind.Relative)).Stream;
            Cursor cursor = new Cursor(stream, true );
            return cursor;
		}
        public static Cursor WhiteCursor => LoadCursor("Assets/CursorW.cur");
		public static Cursor BlackCursor => LoadCursor("Assets/CursorB.cur");

	}
}
