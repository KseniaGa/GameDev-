using System;

namespace ROBOTS
{
	public class Cyborg : Robot
	{
		public Cyborg()
		{
			setBattery(25);
			setWC(25);
			setName("C");
		}

		//BIGGER WEIGHTCAPACITY THAN SMARTY BUT LESS THAN WORKER (25, 25)

	}

	public class SmartRobot : Robot
	{


		public SmartRobot()
		{
			setBattery(20);
			setWC(20);
			setName("S");
		}
		// (20,20)

	}


	public class WorkerRobot : Robot
	{

		//MORE WEIGHTCAPACITY AND BATTERY THAN SMART (30,30)
		public WorkerRobot()
		{
			setBattery(30);
			setWC(30);
			setName("W");
		}
	}

}
