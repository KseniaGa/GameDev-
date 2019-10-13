using System;


namespace ROBOTS
{

	public class RobotFactory
	{

		public makeRobot()
		{
			Robot newRobot = null;

			String robotProb() {

				List<KeyValuePair<string, double>> elements = { new KeyValuePair<string, double>("C", 0.3), new KeyValuePair<string, double>("SR", 0.2), new KeyValuePair<string, double>("WR", 0.5) };
				Random r = new Random();
				double diceRoll = r.NextDouble();

				double cumulative = 0.0;
				for (int i = 0; i < elements.Count; i++)
				{
					cumulative += elements[i].Value;
					if (diceRoll < cumulative)
					{
						string selectedElement = elements[i].Key;
						break;
					}
				}

				return selectedElement;

			}

			String newRobotType = robotProb();


			if (newRobotType.equals("C"))
			{
				return new Cyborg();
			}
			else if (newRobotType.equals("W"))
			{
				return new WorkerRobot();
			}
			else if (newRobotType.equals("S"))
			{
				return new SmartRobot();
			}
			else return null;
		}

	}


}