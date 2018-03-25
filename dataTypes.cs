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
		public int arrivalTime;
		public int burstTime;
		public int priority;
		public int startTime;
		public int waitingTime;
		public int finishTime;
	}
	enum sort { arrivalTime=0, priority=1, index=2 };
}
