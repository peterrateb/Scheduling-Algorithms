using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dataTypes
{
	struct process
	{
		public string name;
		public float arrivalTime;
		public float burstTime;
		public int priority;
		public float startTime;
		public float waitingTime;
		public float finishTime;
	}
	enum sort { arrivalTime=0, priority=1 };
}
