﻿#region MIT License
/*Copyright (c) 2012 Robert Rouhani <robert.rouhani@gmail.com>

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/
#endregion

using System;
using System.Runtime.InteropServices;

using SharpFont.Internal;

#if FT64
using FT_Long = System.Int64;
using FT_ULong = System.UInt64;
using FT_Fixed = System.Int64;
using FT_Pos = System.Int64;
using FT_26Dot6 = System.Int64;
#else
using FT_Long = System.Int32;
using FT_ULong = System.UInt32;
using FT_Fixed = System.Int32;
using FT_Pos = System.Int32;
using FT_26Dot6 = System.Int32;
#endif

namespace SharpFont
{
	/// <summary>
	/// A structure used to hold an outline's bounding box, i.e., the
	/// coordinates of its extrema in the horizontal and vertical directions.
	/// </summary>
	public sealed class BBox
	{
		internal IntPtr reference;
		internal BBoxInternal bboxInternal;

		internal BBox(IntPtr reference)
		{
			this.reference = reference;
			this.bboxInternal = (BBoxInternal)Marshal.PtrToStructure(reference, typeof(BBoxInternal));
		}

		internal BBox(BBoxInternal bboxInt)
		{
			this.bboxInternal = bboxInt;
		}

		/*/// <summary>
		/// Gets the size of the class, in bytes.
		/// </summary>
		public static int SizeInBytes
		{
			get
			{
				return IntPtr.Size * 4;
			}
		}*/

		/// <summary>
		/// The horizontal minimum (left-most).
		/// </summary>
		public int Left
		{
			get
			{
				return bboxInternal.xMin;
			}
		}

		/// <summary>
		/// The vertical minimum (bottom-most).
		/// </summary>
		public int Bottom
		{
			get
			{
				return bboxInternal.yMin;
			}
		}

		/// <summary>
		/// The horizontal maximum (right-most).
		/// </summary>
		public int Right
		{
			get
			{
				return bboxInternal.xMax;
			}
		}

		/// <summary>
		/// The vertical maximum (top-most).
		/// </summary>
		public int Top
		{
			get
			{
				return bboxInternal.yMax;
			}
		}
	}
}
