using System;
using System.Collections.Generic;


namespace ROBOTS
{

	public class RobotFactory
	{

		public Robot makeRobot()
		{



			String robotProb() {

				String selectedElement = null; 

				List<KeyValuePair<string, double>> elements = new List<KeyValuePair<string, double>> { new KeyValuePair<string, double>("C", 0.3), new KeyValuePair<string, double>("S", 0.2), new KeyValuePair<string, double>("W", 0.5) };
				Random r = new Random();
				double diceRoll = r.NextDouble();

				double cumulative = 0.0;
				for (int i = 0; i < elements.Count; i++)
				{
					cumulative += elements[i].Value;
					if (diceRoll < cumulative)
					{
						selectedElement = elements[i].Key;
						break;
					}
				}

				return selectedElement;

			}


			String newRobotType = robotProb();


			if (newRobotType =="C")
			{
				return new Cyborg();
			}
			else if (newRobotType == "W")
			{
				return new WorkerRobot();
			}
			else if (newRobotType == "S" )
			{
				return new SmartRobot();
			}
			else return null;
		}

	}


}