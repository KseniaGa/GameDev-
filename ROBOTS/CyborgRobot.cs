using System;

namespace ROBOTS
{
	public class Cyborg : Robot
	{
		public Cyborg()
		{
			setBattery(25);
			setWC(25);
			setName("Cyborg");
		}

		//BIGGER WEIGHTCAPACITY THAN SMARTY BUT LESS THAN WORKER (25, 25)

	}

	public class SmartRobot : Robot
	{

		// (20,20)

	}


	public class WorkerRobot : Robot
	{

		//MORE WEIGHTCAPACITY AND BATTERY THAN SMART (30,30)

	}

}
