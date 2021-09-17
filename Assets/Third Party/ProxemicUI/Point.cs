/// ------------------------------------------------------------------------------------------------
/// 
/// Project:        ProxemicUIFramework
/// Description:    This framework was build to provide developers the support to build proxemics
///                 aware applications. It provides developers a set of proxemic events based on 
///                 proxemics data of entities , that include absolute data of entities in an 
///                 environment, relative data between entities in that environment, and combanation
///                 of any of these data. It also provides developers with a combanation of proxemic
///                 events and UI events which we call Hybrid Events.
/// Version:        1.0
/// Author:         Mohammed Alnusayri
/// Contact:        m.alnusayri@gmail.com
/// 
/// -------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
//ing System.Windows.Media.Media3D;
//using System.Windows.Media;
using System.Numerics;

namespace ProxemicUIFramework
{
    /// <summary>
    /// <c>Point</c> is created in an entity that has a point shape to check the distance to any other entity  
    /// </summary>
    public class Point : Geometry
    {
        /// <summary>
        /// default shape ID 
        /// </summary>
        protected int shapeId = 0;

        private double xPosition, yPosition,zPosition, oriYaw, oriPitch, oriRoll;
        /// <summary>
        /// sets the position of the entity
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void SetPosition(double x, double y, double z)
        {
            this.xPosition = x;
            this.yPosition = y;
            this.zPosition = z;
        }
        /// <summary>
        /// to retrieve position of an entity
        /// </summary>
        /// <returns></returns>
        public override Position GetPosition()
        {
            return new Position(xPosition, yPosition, zPosition);
        }
        /// <summary>
        /// class main constructor
        /// </summary>
        public Point()
        {
        }
        /// <summary>
        /// to retrieve shape id of an entity
        /// </summary>
        public override int ShapeId
        {
            get { return shapeId; }
        }

        // those are here only because all abstract properties must be implemented in all inherited classes
        public override double Width {get; set;}
        public override double Length { get; set; }
        /// <summary>
        /// to store and retrieve orientation of an entity
        /// </summary>
        public override void SetOrientation(double yaw, double pitch, double roll)
        {
            this.oriYaw = yaw;
            this.oriPitch = pitch;
            this.oriRoll = roll;
        }
        /// returns Orientation data (yaw, pitch, roll)
        public override Orientation GetOrientation()
        {
            return new Orientation(oriYaw, oriPitch, oriRoll);
        }
        /*public override int Orientation
        {
            get { return orientation; }
            set { orientation = value; }
        }*/
        /// <summary>
        /// <c>CheckDistance</c> is the checker method between all entities (for all shapes)
        /// </summary>
        /// <remarks>all <c>Geometry</c> classes (shapes) has one <c>CheckDistance</c> method
        /// that include checkers between all shapes.
        /// <c>CheckDistance</c> method is called in <c>test</c> method within each rule. The way it works is
        /// <c>CheckDistance</c> method is called thorugh the shape of an entity, and its arguments are the 
        /// shape of the other entity that we want to compare with as well as the thresholds. Then the checker 
        /// method will use shape data of current entity and compare it with shape data of passed entity, then 
        /// return the results</remarks>
        /// <param name="g">shape of type <c>Geometry</c></param>
        /// <param name="minimumThreshold">minimum Threshold</param>
        /// <param name="maximumThreshold">maximum Threshold</param>
        /// <returns></returns>
        public override bool CheckDistance(Geometry g, double minimumThreshold, double maximumThreshold, Rules rule)
        {
            // retrieve positions of entities
            Position position = g.GetPosition();
            // calculate actual distance thershold
            double distanceThreshold = maximumThreshold - minimumThreshold;
            // to be used for calculating distacne from corners in case of the entity has a rectangel shape
            double cornerDistance_sq = 0;

            // to check distance in case of both entities have shape of a point (point to point)
            if (g.ShapeId == this.ShapeId)
            {
                // calculate positions difference 
                double distance = Math.Sqrt(Math.Pow(this.xPosition - position.X, 2) + Math.Pow(this.zPosition - position.Z, 2));
                //double x = GetAbsDifference(this.xPosition, position.X);
                //double z = GetAbsDifference(this.zPosition, position.Z);
                // compare positions difference with threshold
                if (distance >= minimumThreshold && distance <= maximumThreshold)// && z > minimumThreshold && z < maximumThreshold)
                    return true;
            }
            else
                // to check distance in case of one entity has a shape of a point and the other one has a shap of a rectangle (point to rectangle)
                if (g.ShapeId == Convert.ToInt32(GeomtryIDs.Rectangle))
                {
                    // calculate absolute distance between point and center of a rectangle (table). (This is to check distance to the edges of the table)
                    Position absoluteDistance = new Position();
                    absoluteDistance.X = Math.Abs(this.xPosition - (position.X + g.Width / 2));
                    absoluteDistance.Z = Math.Abs(this.zPosition - (position.Z + g.Length / 2));

                    // to check if the point (entity) is within the threshold at edges
                    if (absoluteDistance.X <= g.Width / 2 + distanceThreshold && absoluteDistance.Z <= g.Length / 2 + distanceThreshold)
                        return true;

                    // to calculate if a point (entity) is within the threshold at corners of a rectangle (table)
                    cornerDistance_sq = Math.Pow((absoluteDistance.X - g.Width / 2), 2)
                        + Math.Pow((absoluteDistance.Z - g.Length / 2), 2);

                    if (cornerDistance_sq <= (Math.Pow(distanceThreshold, 2)))
                        return true;
                }
            return false;
        }
        /// <summary>
        /// check absolute orientation, this is done by checking each axis independatly where developer passes thresholds for a single axis
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="minimumThreshold"></param>
        /// <param name="maximumThreshold"></param>
        /// <returns></returns>
        public override bool CheckAbsoluteOrientation(double axis, double minimumThreshold, double maximumThreshold)
        {
            if (axis > minimumThreshold && axis < maximumThreshold)
                return true;
            else
                return false;
        }
        /// <summary>
        /// check absolute orientation, this is done by checking each axis where developer passes thresholds for all axes
        /// </summary>
        /// <param name="axes"></param>
        /// <param name="minimumThreshold"></param>
        /// <param name="maximumThreshold"></param>
        /// <returns></returns>
        public override bool CheckAbsoluteOrientation(Orientation axes, List<double> minimumThreshold, List<double> maximumThreshold)
        {
            if (axes.Yaw > minimumThreshold[0] && axes.Yaw < maximumThreshold[0] &&
                axes.Pitch > minimumThreshold[1] && axes.Pitch < maximumThreshold[1] &&
                axes.Roll > minimumThreshold[2] && axes.Roll < maximumThreshold[2])
                return true;
            else
                return false;
        }

        public override bool MobilityCheck(Position oldPosition, Position newPosition, double Threshold)
        {
            if (Math.Abs(oldPosition.X - newPosition.X) > Threshold || Math.Abs(oldPosition.Z - newPosition.Z) > Threshold)
                return true;
            else
                return false;
        }

        public override bool CheckRelativeOrientation(Geometry g, double Threshold)
        {
            Position position = g.GetPosition();
            Orientation orientation = g.GetOrientation();

            double FirstObjectRotation = FacingAngleCalculator(new Vector2((float)this.xPosition, (float)this.zPosition), new Vector2((float)position.X, (float)position.Z));

            double SecondObjectRotation = FacingAngleCalculator(new Vector2((float)position.X, (float)position.Z), new Vector2((float)this.xPosition, (float)this.zPosition));

            bool FirstObjectCheck = FacingAngleDetector(this.oriYaw, FirstObjectRotation, Threshold);
            bool SecondObjectCheck = FacingAngleDetector(orientation.Yaw, SecondObjectRotation, Threshold);

            if (FirstObjectCheck && SecondObjectCheck)
                return true;
            else
                return false;
            /*for (int i = 0; i < Thresholds.Count; i++)
            //foreach(List<Tuple<double, double>> threshold in Thresholds)
            {
                // retrive thresholds
                double minimumThreshold = Thresholds[i].Item1, maximumThreshold = Thresholds[i].Item2; 

                // claculate the difference between two orintations in YAW
                double difference = 180 - Math.Abs(Math.Abs(this.oriYaw - orientation.Yaw) - 180);

                if (difference <= maximumThreshold && difference >= minimumThreshold)
                {
                    // calculate positions difference 
                    double originalDistance = Math.Sqrt(Math.Pow(this.xPosition - position.X, 2) + Math.Pow(this.zPosition - position.Z, 2));
                    double newDistance;

                    Vector firstPoint = new Vector(this.xPosition, this.zPosition);

                    if (Math.Abs(this.zPosition - position.Z) > Math.Abs((this.zPosition + 10) - (position.Z + 10)))
                    {

                    }
                }
            }*/
        }

        // check if an object is facing a point/another object
        public override bool IsFacing(Vector3 Target, double Threshold)
        {
            double ObjectRotation = FacingAngleCalculator(new Vector2((float)this.xPosition, (float)this.zPosition), new Vector2(Target.X, Target.Z));

            bool ObjectCheck = FacingAngleDetector(this.oriYaw, ObjectRotation, Threshold);

            if (ObjectCheck)
                return true;
            else 
                return false;
        }
    }
}
