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
using Bespoke.Common;
using Bespoke.Common.Osc;
using System.Net;

namespace ProxemicUIFramework
{
    /// <summary>
    /// <c>DataReceiver</c> receives OSC messages that contain data of tracked entities (e.g. ID, x, y, etc.),
    /// then, it break each message into seperate entities, then pass them to <c>EntitiyContainer</c> to create 
    /// instances of proximity entity for all received entities.
    /// </summary>
    public class DataReceiver
    {
        //EntityContainer entityContainer = new EntityContainer();
        Geometry Geometry;

        /// <summary>
        /// For OSC communication setup
        /// </summary>
        //private static readonly int Port = 5103;
        private static readonly string AliveMethod = "/osctest/alive";
        private static readonly string TestMethod = "/osctest/test";
        private static OscServer oscServer;
        /// <summary>
        /// <c>DataReceiver</c> contains a full setup of OSC communication 
        /// </summary>
        public DataReceiver(int Port, string IPaddress)
        {
            try
            {
                // Use this to receive data from the same machine
                //oscServer = new OscServer(TransportType.Udp, IPAddress.Loopback, Port);

                // Use this to receive messages from a different machine (replace IP address bellow with the IP of the current machine)
                oscServer = new OscServer(System.Net.TransportType.Udp, IPAddress.Parse(IPaddress), Port);

                oscServer.FilterRegisteredMethods = false;
                oscServer.RegisterMethod(AliveMethod);
                oscServer.RegisterMethod(TestMethod);
                oscServer.MessageReceived += new EventHandler<OscMessageReceivedEventArgs>(oscServer_MessageReceived);
                oscServer.ReceiveErrored += new EventHandler<Bespoke.Common.ExceptionEventArgs>(oscServer_ReceiveErrored);
                oscServer.ConsumeParsingExceptions = false;
                oscServer.Start();
                System.Console.WriteLine("start to receive messages");

            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught: ", e);
            }
        }

        /// <summary>
        /// <c>oscServer_MessageReceived</c> method receives data of entities (e.g. ID, x, y, etc.)
        /// through OSC messages; then call <c>EntityChecker</c> method form <c>EntityContainer</c>
        /// to create new <c>ProximityEntity</c>, update data of an entity, or delete an entity.
        /// The format of OSC message is, [/trackers/, timestamp, id, x, y, z, yaw, pitch, roll, id, x, y, z, yaw, pitch, roll....].
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oscServer_MessageReceived(object sender, OscMessageReceivedEventArgs e)
        {

            OscMessage message = e.Message;
            int count = message.Data.Count, dataCount = 8;

            Dictionary<string, List<double>> entities = new Dictionary<string, List<double>>();
            List<double> data = new List<double>();

            string timestamp = "";
            // store data of entities, the received format is (timestamp, serial number, x, y, z, yaw, pitch, roll)
            if (message.Address == "/trackers/")
            {
                timestamp = (string)message.Data[0];
                for (int i = 1; i < count; i++)
                {
                    data = new List<double>();
                    for (int j = i + 1; j < dataCount; j++)
                    {
                        data.Add(Convert.ToDouble(message.Data[j]));
                    }
                    entities[Convert.ToString(message.Data[i])] = data;
                    i += 6;
                    dataCount = i + 8;
                }
                EntityContainer.Instance.EntityChecker(timestamp, entities);
            }
            else
                // store other data of entities (width, length) 
                if (message.Address == "/tabletop/")
            {
                Geometry.ShapeConverter(message);
            }
            /*for (int i = 0; i < count; i++)
            {
                string id = (string)message.Data[i]; // ID
                double w = (double)message.Data[i + 1]; // width
                double l = (double)message.Data[i + 2]; // length
                i = i + 2;

                entityContainer.EntityChecker(id, w, l);
            }
        }
    /// Store Users' Information
    /*if (message.Address == "/test")
    {
        // get number of users
        int NumberOfMobileEntities = (int)message.Data[0];

        // Store users' information
        // the formula "[i * 3 + 1]" would change based on the format of OSC messages
        // (e.g. number of received data (ID, x, y, ori, etc.))
        for (int i = 0; i < NumberOfMobileEntities; ++i)
        {
            int id = (int)message.Data[i * 3 + 1]; // ID
            int x = (int)message.Data[i * 3 + 2]; // X
            int y = (int)message.Data[i * 3 + 3]; // Y
            // ori = (int)message.Data[i * 4 + 4]; // Orientation

            // pass recieved data to create/update/remove entities 
            entityContainer.EntityChecker(id, x, y);
        }
    }*/
        }
        /// <summary>
        /// OSC Exception message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oscServer_ReceiveErrored(object sender, Bespoke.Common.ExceptionEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Error during reception of packet: {0}", e.Exception.Message);
        }
    }
}
