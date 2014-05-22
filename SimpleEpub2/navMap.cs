using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleEpub2
{
	public class navPoint
	{
		private String id;
		private Int32 playOrder;
		private String text;
		private String src;
		private navPoint parent;
		private List<navPoint> child;

		public navPoint()
		{
			this.id = "";
			this.playOrder = 0;
			this.text = "";
			this.src = "";
			this.parent = null;
			this.child = new List<navPoint>();
		}

		public navPoint(String id, Int32 playOrder, String text, String src, navPoint parent, List<navPoint> child)
		{
			this.id = id;
			this.playOrder = playOrder;
			this.text = text;
			this.src = src;
			this.parent = parent;
			if (child == null)
			{
				this.child = new List<navPoint>();
			}
			else this.child = child;
		}

		public String ID { get; set; }
		public Int32 PLAYORDER { get; set; }
		public String TEXT { get; set; }
		public String SRC { get; set; }
		public navPoint PARENT { get; set; }
		public List<navPoint> CHILD { get; set; }

		private void sister(navPoint s)
		{
			s.PARENT = this.parent;
			if (this.parent.CHILD == null)
				this.parent.CHILD = new List<navPoint>();
			this.parent.CHILD.Add(s);
		}

		public StringBuilder printNP()
		{
			StringBuilder toPrint = new StringBuilder();

			if (this.CHILD == null)
			{
				toPrint.Append("<navPoint id=\"" + this.id + "\" playOrder=\"" + this.playOrder + "\"><navLabel><text>" + this.text + "</text></navLabel><content src=\"" + this.src + "\"/></navPoint>\n");
			}
			else
			{
				toPrint.Append("<navPoint id=\"" + this.id + "\" playOrder=\"" + this.playOrder + "\"><navLabel><text>" + this.text + "</text></navLabel><content src=\"" + this.src + "\"/>\n");

				for (Int32 i = 0; i < this.CHILD.Count; i++)
				{
					toPrint.Append(this.CHILD[i].printNP());
				}

				toPrint.Append("</navPoint>\n");
			}

			return toPrint;
		}

	}

	public class navMap
	{
		List<navPoint> vpList;

		public navMap()
		{
			this.vpList = new List<navPoint>();
		}

		public navMap(List<navPoint> l)
		{
			this.vpList = l;
		}

		public navMap(List<Tuple<Int32, navPoint>> l, Int32 maxCount)
		{
			vpList = new List<navPoint>();

			if (l[0] != null)
			{
				vpList.Add(l[0].Item2);

				if (l.Count > 1 && l[1] != null)
				{
					Int32 prevCount = l[0].Item1;
					for (Int32 i = 1; i < l.Count; i++)
					{
						if (l[i].Item1 == prevCount)
						{
							if (prevCount == 0)
							{
								vpList.Add(l[i].Item2);
							}
							else if (prevCount == 1)
							{
								l[i].Item2.PARENT = vpList[vpList.Count - 1];

								if (vpList[vpList.Count - 1].CHILD == null)
									vpList[vpList.Count - 1].CHILD = new List<navPoint>();

								vpList[vpList.Count-1].CHILD.Add(l[i].Item2);
							}
							else if (prevCount == 2)
							{
								l[i].Item2.PARENT = vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1];

								if (vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD == null)
									vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD = new List<navPoint>();

								vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD.Add(l[i].Item2);
							}
							else	// prevCount == 3
							{
								l[i].Item2.PARENT = vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD.Count - 1];

								if (vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD.Count - 1].CHILD == null)
									vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD.Count - 1].CHILD = new List<navPoint>();

								vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD.Count - 1].CHILD.Add(l[i].Item2);
							}
						}
						else if (l[i].Item1 > prevCount)
						{
							if (prevCount == 0)
							{
								l[i].Item2.PARENT = vpList[vpList.Count - 1];

								if (vpList[vpList.Count - 1].CHILD == null)
									vpList[vpList.Count - 1].CHILD = new List<navPoint>();

								vpList[vpList.Count - 1].CHILD.Add(l[i].Item2);
							}
							else if (prevCount == 1)
							{
								l[i].Item2.PARENT = vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count-1];

								if (vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD == null)
									vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD = new List<navPoint>();

								vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD.Add(l[i].Item2);
							}
							else	// prevCount == 2
							{
								l[i].Item2.PARENT = vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD.Count - 1];

								if (vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD.Count - 1].CHILD == null)
									vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD.Count - 1].CHILD = new List<navPoint>();

								vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD.Count - 1].CHILD.Add(l[i].Item2);
							}
						}
						else	// (l[i].Item1 < prevCount)
						{
							if (l[i].Item1 == 0)
							{
								vpList.Add(l[i].Item2);
							}
							else if (l[i].Item1 == 1)
							{
								l[i].Item2.PARENT = vpList[vpList.Count - 1];

								if (vpList[vpList.Count - 1].CHILD == null)
									vpList[vpList.Count - 1].CHILD = new List<navPoint>();

								vpList[vpList.Count - 1].CHILD.Add(l[i].Item2);
							}
							else	// l[i].Item1 == 2
							{
								l[i].Item2.PARENT = vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1];

								if (vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD == null)
									vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD = new List<navPoint>();

								vpList[vpList.Count - 1].CHILD[vpList[vpList.Count - 1].CHILD.Count - 1].CHILD.Add(l[i].Item2);
							}
						}

						prevCount = l[i].Item1;

					}
				}
			}
		}

		public List<navPoint> LIST { get { return vpList; } }

		public StringBuilder printNM()
		{
			StringBuilder toPrint = new StringBuilder();

			if (this.vpList == null)
			{
				toPrint.Append("<navMap>\n</navMap>\n");
			}
			else
			{
				toPrint.Append("<navMap>\n");

				for (Int32 i = 0; i < this.vpList.Count; i++)
				{
					toPrint.Append(this.vpList[i].printNP());
				}

				toPrint.Append("</navMap>\n");
			}

			return toPrint;
		}

	}

	
}
