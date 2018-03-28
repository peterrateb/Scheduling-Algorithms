using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dataTypes
{
	struct process
	{
		public string name;
		public int index;
		public float arrivalTime;
		public float burstTime;
		public float priority;
		public float startTime;
		public float waitingTime;
		public float finishTime;
	}
	enum sort { arrivalTime = 0, priority = 1, index = 2 };
}
