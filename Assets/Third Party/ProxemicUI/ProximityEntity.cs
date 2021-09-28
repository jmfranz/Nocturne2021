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

namespace ProxemicUIFramework
{
    public enum EntityTypeIDs
    {
        person = 0, table = 1, tablet = 2
    }
    /// <summary>
    /// <c>ProximityEntity</c> contains all properties of a <c>ProximityEntity</c>
    /// </summary>
    public class ProximityEntity
    {
        protected string entityId, timeStamp;

        private Geometry shape;

        private int shapeId, entityTypeId;

        private bool isStable, isActive;

        /// <summary>
        /// class main constructor that only takes entity id
        /// </summary>
        /// <param name="id"></param>
        public ProximityEntity(string id)
        {
            this.entityId = id;
        }
        /// <summary>
        /// to update properties of en entity, it has only two parameters to match received OSC
        /// data, this method can be modified as required
        /// </summary>
        /// <param name="t">time stamp</param>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <param name="z">z</param>
        /// <param name="yaw">yaw</param>
        /// <param name="pitch">pitch</param>
        /// <param name="roll">roll</param>
        /// <param name="active">true or false</param>
        public void UpdateProperties(string t, double x, double y, double z, double yaw, double pitch, double roll, bool active)
        {
            this.TimeStamp = t;
            this.SetPosition(x, y, z);
            this.SetOrientation(yaw, pitch, roll);
            this.isActive = active;
        }
        /// <summary>
        /// to store and retrieve entity id
        /// </summary>
        public string EntityID
        {
            get { return entityId; }
            set { entityId = value; }
        }
        /// <summary>
        /// store and retrieve when data of entity was captured
        /// </summary>
        public string TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }
        /// <summary>
        /// to retrieve (x, y, z) position of an entity
        /// </summary>
        /// <remarks>Position will be used to store top-left corner when the entity is a tabletop</remarks>
        /// <returns>(x, y, z)</returns>
        public Position GetPosition()
        {
            return this.Shape.GetPosition();
        }
        /// <summary>
        /// to store (x, y) position of an entity
        /// </summary>
        /// <param name="x">entity position (x)</param>
        /// <param name="y">entity position (y)</param>
        public void SetPosition(double x, double y, double z)
        {
            this.Shape.SetPosition(x, y, z);
        }
        /// <summary>
        /// to store and retrieve orientation of an entity (yaw, pitch, roll)
        /// </summary>
        /*public int Orientation
        {
            get { return this.Shape.Orientation; }
            set { this.Shape.Orientation = value; }
        }*/
        public void SetOrientation(double yaw, double pitch, double roll)
        {
            this.Shape.SetOrientation(yaw, pitch, roll);
        }

        public Orientation GetOrientation()
        {
            return this.Shape.GetOrientation();
        }
        /// <summary>
        /// to store and retrieve the status (stable, mobile) of an entity
        /// </summary>
        public bool IsStable
        {
            get { return isStable; }
            set { isStable = value; }
        }
        /// <summary>
        /// when tracking data of is not received anymore the entity will be inActive  
        /// </summary>
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        /// <summary>
        /// to set and retrieve entity type (e.g. person or table)
        /// each type has a uniqe ID as implemented on top of this calss
        /// </summary>
        public int EntityTypeID
        {
            get { return entityTypeId; }
            set { entityTypeId = value; }
        }
        /// <summary>
        /// to store and retrieve shape id of an entity
        /// </summary>
        /// <remarks>each entity has a shape and each shape has an ID, this way it is easer
        /// to test proxemic data of different entities that has different shapes </remarks>
        public int ShapeId
        {
            get { return shapeId; }
            set { shapeId = value;
                if (shapeId == Convert.ToInt32(GeomtryIDs.Point))
                    shape = new Point();
                else
                        if (shapeId == Convert.ToInt32(GeomtryIDs.Rectangle))
                    shape = new Rectangle();
            }
        }
        /// <summary>
        /// to set and retrieve shape of entity based on shape id 
        /// </summary>
        public Geometry Shape
        {
            get
            {return shape;}            
        }
        
    }
    /// <summary>
    /// <c>Position</c> is a struct to store position (x,y,z) in a single variable
    /// </summary>
    public struct Position
    {
        double x;
        double y;
        double z;

        public double X
        {
            get { return x; }
             set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public Position(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    public struct Orientation
    {
        double yaw;
        double pitch;
        double roll;

        public double Yaw
        {
            get { return yaw; }
            set { yaw = value; }
        }

        public double Pitch
        {
            get { return pitch; }
            set { pitch = value; }
        }

        public double Roll
        {
            get { return roll; }
            set { roll = value; }
        }

        public Orientation(double yaw, double pitch, double roll)
        {
            this.yaw = yaw;
            this.pitch = pitch;
            this.roll = roll;
        }
    }

}
