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
    /// <summary>
    /// <c>EntityContainer</c> receives data of entities (e.g. ID, x, y, etc.) form <c>DataRecevier</c>, 
    /// then creates an instance of proximity entity for each received entity. 
    /// </summary>
    public sealed class EntityContainer
    {
        /// <summary>
        /// to store all received entities
        /// </summary>
        public static Dictionary<string, ProximityEntity> ListOfEntities = new Dictionary<string, ProximityEntity>();

        public delegate void IDRemovedHandler(string id);
        public event IDRemovedHandler EntityInActiveEvent;

        private static EntityContainer instance = new EntityContainer();
        private EntityContainer()
        {  
        }
        public static EntityContainer Instance
        {
            get { return instance; }
        }
        /// <summary>
        /// a method that recieves data of entities to create new <c>ProximityEntity</c>, 
        /// update data of an entity, or delete an entity.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /*public void EntityChecker(int id, int x, int y)
        {
            // checkes If an entity is already exist
            if (ListOfEntities.ContainsKey(id))
            {
                // remove the entity when x = 9999
                // When an entity is no longer being tracked, the sender must send its data once
                // inluding its ID and the value of x = 9999, then, this method will delete the entity 
                // and fire IdRemovedEvent.
                if (x == 9999)
                {
                    ListOfEntities.Remove(id);
                    OnEntityRemovedEvent(id);
                }
                // update data of entity (x, y)
                else
                {
                    //ListOfEntities[id].SetPosition(x, y);
                    ListOfEntities[id].UpdateProperties(x, y);
                }
            }

            // create new entity and add to dictionary
            else
            {
                ProximityEntity entity = new ProximityEntity(id);
                entity.SetPosition(x, y);
                ListOfEntities.Add(id, entity);
            }
        }*/
        public void EntityChecker(string timestamp, Dictionary<string, List<double>> entities)
        {
            // start with checking if the existing list of entities contains the entities we recived data for
            foreach (KeyValuePair<string, ProximityEntity> pair in ListOfEntities)
            {
                // if the new list conatins the entity from the existing list, this updates its data
                if (entities.ContainsKey(pair.Key))
                {
                    //update data
                    List<double> data = entities[pair.Key];
                    ListOfEntities[pair.Key].UpdateProperties(timestamp, data[0], data[1], data[2], data[3], data[4], data[5], true);
                }
                // if the new list doesn't contain the entity from the existing list, this change the entity status to inactive and fire the inactive event
                else
                {
                    ListOfEntities[pair.Key].IsActive = false;
                    OnEntityInActiveEvent(pair.Key);
                }
            }
            // if the entity is new, this creates a new entity then add it to the list 
            foreach (KeyValuePair<string, List<double>> pair in entities)
            {
                if (ListOfEntities.ContainsKey(pair.Key) == false)
                {
                    List<double> data = pair.Value;
                    ProximityEntity newEntity = new ProximityEntity(pair.Key);
                    newEntity.ShapeId = 0; 
                    newEntity.SetPosition(data[0], data[1], data[2]);
                    newEntity.SetOrientation(data[3], data[4], data[5]);
                    ListOfEntities.Add(pair.Key, newEntity);
                }
            }
            // call the logger method
            DataLogger.EntityDataLogger();
        }
        // this is to store any other data for entities (e.g. length and width)
        // 
        public void EntityChecker(string Id, double Width, double Length, int shapId, Position position, Orientation orientation)
        {
            if (ListOfEntities.ContainsKey(Id))
            {
                ListOfEntities[Id].ShapeId = shapId;
                ListOfEntities[Id].SetPosition(position.X, position.Y, position.Z);
                ListOfEntities[Id].SetOrientation(orientation.Yaw, orientation.Pitch, orientation.Roll);
                ListOfEntities[Id].Shape.Width = Width;
                ListOfEntities[Id].Shape.Length = Length;
            }
            // call the logger method
            DataLogger.EntityDataLogger();
        }
        /// <summary>
        /// to retrieve entities by type (e.g. table, persone, cellphone, etc.) through testeing
        /// recieved id against typeId of each entity.
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public static List<string> EntityRetrievalByType(int TypeId)
        {
            if (ListOfEntities.Count == 0)
                throw new Exception("DataReceiver Did not receive any data yet! Make sure you are initializing the connection");

            Dictionary<string, ProximityEntity> _TemporaryList = new Dictionary<string, ProximityEntity>(ListOfEntities);

            List<string> ids = new List<string>();

            foreach (KeyValuePair<string, ProximityEntity> pair in _TemporaryList)
            {
                if (pair.Value.EntityTypeID == TypeId)
                {
                    ids.Add(pair.Key);
                }
            }
            return ids;
        }
        /// <summary>
        /// to retrieve entities by shape (e.g. rectangle, point, etc.) through testeing
        /// recieved id against shapeId of each entity.
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public static List<string> EntityRetrievalByShape(int ShapeId)
        {
            if (ListOfEntities.Count == 0)
                throw new Exception("DataReceiver Did not receive any data yet! Make sure you are initializing the connection");

            Dictionary<string, ProximityEntity> _TemporaryList = new Dictionary<string, ProximityEntity>(ListOfEntities);

            List<string> ids = new List<string>();

            foreach (KeyValuePair<string, ProximityEntity> pair in _TemporaryList)
            {
                if (pair.Value.ShapeId == ShapeId)
                {
                    ids.Add(pair.Key);
                }
            }
            return ids;
        }
        /// <summary>
        /// to retrieve entities by mobility status (e.g. mobile, stable) through testeing
        /// recieved status against the status <c>IsStable</c> of each entity. if the recieved status is
        /// true, it will return all stable entities. if the recieved status is false it
        /// will return all mobile entities.
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public static List<string> EntityRetrievalByMobilityStatus(bool status)
        {
            if (ListOfEntities.Count == 0)
                throw new Exception("DataReceiver Did not receive any data yet! Make sure you are initializing the connection");

            Dictionary<string, ProximityEntity> _TemporaryList = new Dictionary<string, ProximityEntity>(ListOfEntities);

            List<string> ids = new List<string>();

            foreach (KeyValuePair<string, ProximityEntity> pair in _TemporaryList)
            {
                if (pair.Value.IsStable == status)
                {
                    ids.Add(pair.Key);
                }
            }
            return ids;
        }
        /// <summary>
        /// to retrieve entities by Activation status (e.g. active, inactive) through testeing
        /// recieved status against the status <c>IsActive</c> of each entity. if the recieved status is
        /// true, it will return all active entities. if the recieved status is false it
        /// will return all inActive entities.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<string> EntityRetrievalByActivationStatus(bool status)
        {
            if (ListOfEntities.Count == 0)
                throw new Exception("DataReceiver Did not receive any data yet! Make sure you are initializing the connection");

            Dictionary<string, ProximityEntity> _TemporaryList = new Dictionary<string, ProximityEntity>(ListOfEntities);

            List<string> ids = new List<string>();

            foreach (KeyValuePair<string, ProximityEntity> pair in _TemporaryList)
            {
                if (pair.Value.IsActive == status)
                {
                    ids.Add(pair.Key);
                }
            }
            return ids;
        }
        /// <summary>
        /// to retrieve all entities 
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns></returns>
        public static List<string> EntityRetrievalAll()
        {
            if (ListOfEntities.Count == 0)
                throw new Exception("DataReceiver Did not receive any data yet! Make sure you are initializing the connection");

            List<string> _TemporaryList = new List<string>(ListOfEntities.Keys);

            List<string> ids = new List<string>();

            foreach (string entityID in _TemporaryList)
            {
                ids.Add(entityID);
            }
            return ids;
        }

        public void OnEntityInActiveEvent(string id)
        {
            if (EntityInActiveEvent != null)
                EntityInActiveEvent(id);
        }
    }
}
