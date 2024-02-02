using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MqttJs {
	internal class Lib {
		public static byte[] SegmentToArray(ArraySegment<byte> seg) {
			var arr = seg.Array;
			if (arr != null) {
				byte[] data = new byte[seg.Count];
				Array.Copy(arr, seg.Offset, data, 0, seg.Count);
				return data;
			}
			return [];
		}
		/// <summary> 
		/// 判断是否是不带 BOM 的 UTF8 格式 
		/// </summary> 
		/// <param name=“data“></param> 
		/// <returns></returns> 
		public static bool IsUTF8Bytes(byte[] data) {
			int charByteCounter = 1; //计算当前正分析的字符应还有的字节数 
			byte curByte; //当前分析的字节. 
			for (int i = 0; i < data.Length; i++) {
				curByte = data[i];
				if (charByteCounter == 1) {
					if (curByte >= 0x80) {
						//判断当前 
						while (((curByte <<= 1) & 0x80) != 0) {
							charByteCounter++;
						}
						//标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X 
						if (charByteCounter == 1 || charByteCounter > 6) {
							return false;
						}
					}
				} else {
					//若是UTF-8 此时第一位必须为1 
					if ((curByte & 0xC0) != 0x80) {
						return false;
					}
					charByteCounter--;
				}
			}
			if (charByteCounter > 1) {
				return false;
			}
			return true;
		}
		public static bool IsUTF8Bytes(ArraySegment<byte> seg) {
			return IsUTF8Bytes(SegmentToArray(seg));
		}
		public static bool IsGB2312(byte[] data) {
			for (int i = 0; i < data.Length; i++) {
				byte ch = data[i];
				if (ch == 0 || (ch > 127 && ch < 0xA1) || ch == 0xFF) {
					return false;
				}
			}
			return true;
		}
		public static bool IsGB2312(ArraySegment<byte> seg) {
			return IsGB2312(SegmentToArray(seg));
		}
		public static int StringToDarkColor(string str) {
			byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(str));

			int limit = 180;
			int step = 30;
			int max = limit / step;
			int r = (bytes[0] % max) * step;
			int g = (bytes[1] % max) * step;
			int b = (bytes[2] % max) * step;

			return Color.FromArgb(r, g, b).ToArgb();
		}
	}
}
