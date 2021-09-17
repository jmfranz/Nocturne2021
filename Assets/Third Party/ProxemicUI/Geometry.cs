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
using Bespoke.Common;
using Bespoke.Common.Osc;
//ing System.Windows.Media.Media3D;
using System.Numerics;

namespace ProxemicUIFramework
{
    /// <summary>
    /// to set an ID to each shape 
    /// </summary>
    public enum GeomtryIDs
    {
        Point = 0, Rectangle = 1
    }
    /// <summary>
    /// <c>Geometry</c> is the base class of all shapes, all shared code can be added here
    /// </summary>
    public abstract class Geometry
    {
        /// <summary>
        /// <c>SetPosition</c> sets the postion of the enitiy
        /// </summary>
        /// <returns></returns>
        public abstract void SetPosition(double x, double y, double z);
        /// <summary>
        /// <c>GetPosition</c> returns position of a point and center point of a rectangle
        /// </summary>
        /// <returns><c>Position</c> (x, y, z)</returns>
        public abstract Position GetPosition();
        /// <summary>
        /// set Orientation data (yaw, pitch, roll)
        /// </summary>
        /// <param name="yaw"></param>
        /// <param name="pitch"></param>
        /// <param name="roll"></param>
        public abstract void SetOrientation(double yaw, double pitch, double roll);
        /// returns Orientation data (yaw, pitch, roll)
        public abstract Orientation GetOrientation();
        /// <summary>
        /// abstract properties for <c>Width</c>, <c>Hight</c>, and <c>ShapeId</c>
        /// </summary>
        public abstract double Width { get; set; }
        public abstract double Length { get; set; }
        //public abstract int Orientation { get; set; }
        public abstract int ShapeId { get; }
        /// <summary>
        /// <c>CheckDistance</c> is the abstract method of all check distance methods
        /// </summary>
        /// <param name="g">shape of entity</param>
        /// <param name="minimumthreshold">minimum threshold</param>
        /// <param name="maximumThreshold">maximum threshold</param>
        /// <returns>true or false</returns>
        public abstract bool CheckDistance(Geometry g, double minimumthreshold, double maximumThreshold, Rules rule);
        /// <summary>
        /// <c>CheckAbsoluteOrientation</c> is the abstract method of all check orientation methods
        /// this method to check single axis
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="minimumThreshold"></param>
        /// <param name="maximumThreshold"></param>
        /// <returns>true or false</returns>
        public abstract bool CheckAbsoluteOrientation(double axis, double minimumThreshold, double maximumThreshold);
        /// <summary>
        /// this method to check all axis (yaw, pitch, roll)
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="minimumThreshold"></param>
        /// <param name="maximumThreshold"></param>
        /// <returns></returns>
        public abstract bool CheckAbsoluteOrientation(Orientation axes, List<double> minimumThreshold, List<double> maximumThreshold);

        public abstract bool CheckRelativeOrientation(Geometry g, double Threshold);

        public abstract bool IsFacing(Vector3 Target, double Threshold);

        public abstract bool MobilityCheck(Position oldPosition, Position newPosition, double Threshold);

        /// <summary>
        /// gets the absolute difference between two values
        /// </summary>
        /// <param name="value1">first value</param>
        /// <param name="value2">second value</param>
        /// <returns>absolute difference</returns>
        private static double GetAbsDifference(double value1, double value2)
        {
            return Math.Abs(value1 - value2);
        }

        public void ShapeConverter(OscMessage message)
        {
            int count = message.Data.Count;

            if (message.Address == "/tabletop/")
            {
                if (EntityContainer.ListOfEntities.ContainsKey((string)message.Data[0]))
                {
                    Geometry geometry = new Rectangle();
                    Position position = EntityContainer.ListOfEntities[(string)message.Data[0]].GetPosition();
                    Orientation orientation = EntityContainer.ListOfEntities[(string)message.Data[0]].GetOrientation();
                                        
                    for (int i = 0; i < count; i++)
                    {
                        string id = (string)message.Data[i]; // ID
                        double w = (double)message.Data[i + 1]; // width
                        double l = (double)message.Data[i + 2]; // length
                        i = i + 2;

                        EntityContainer.Instance.EntityChecker(id, w, l, 1, position, orientation);
                    }
                }
            }
        }

        // how much should A rotate to face B
        protected double FacingAngleCalculator(Vector2 FirstVector, Vector2 SecondVector)
        {
            Vector2 SecondToFirst = new Vector2(SecondVector.Y - FirstVector.Y, SecondVector.X - FirstVector.X);

            double radians = Math.Atan2(SecondToFirst.Y, SecondToFirst.X);

            double degree = ((radians * (180 / Math.PI)) + 360) % 360;

            return degree;
        }

        // check if difference between current angle and rotation to directly face B is within threshold
        protected bool FacingAngleDetector(double CurrentAngle, double Rotation, double Threshold)
        {
            double leftRotation = (Rotation - Threshold + 360) % 360;
            double rightRotation = (Rotation + Threshold + 360) % 360;

            CurrentAngle = (CurrentAngle + 360) % 360;

            if ((leftRotation < rightRotation && CurrentAngle > leftRotation && CurrentAngle < rightRotation)
                || (leftRotation > rightRotation && (CurrentAngle > leftRotation || CurrentAngle < rightRotation)))
                return true;
            else
                return false;
        }
    }
}
