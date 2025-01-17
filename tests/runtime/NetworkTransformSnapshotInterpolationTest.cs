using System.Collections;
using Mirage.Tests.Runtime.ClientServer;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace JamesFrowen.PositionSync.Tests.Runtime
{
    [Category("NetworkPositionSync")]
    public class NetworkTransformSnapshotInterpolationTest : ClientServerSetup<SyncPositionBehaviour>
    {
        //protected override bool AutoAddPlayer => false;

        //protected override void afterStartHost()
        //{
        //    var serverGO = new GameObject("server object");
        //    var clientGO = new GameObject("client object");
        //    spawned.Add(serverGO);
        //    spawned.Add(clientGO);

        //    var serverNI = serverGO.AddComponent<NetworkIdentity>();
        //    var clientNI = clientGO.AddComponent<NetworkIdentity>();

        //    serverNT = serverGO.AddComponent<SyncPositionBehaviour>();
        //    clientNT = clientGO.AddComponent<SyncPositionBehaviour>();

        //    // set up Identitys so that server object can send message to client object in host mode
        //    FakeSpawnServerClientIdentity(serverNI, clientNI);

        //    // reset both transforms
        //    serverGO.transform.position = Vector3.zero;
        //    clientGO.transform.position = Vector3.zero;
        //}

        //protected override void beforeStopHost()
        //{
        //    foreach (GameObject obj in spawned)
        //    {
        //        Object.Destroy(obj);
        //    }
        //}

        public override void ExtraSetup()
        {
            base.ExtraSetup();
            SyncPositionSystem serverSystem = serverGo.AddComponent<SyncPositionSystem>();
            SyncPositionSystem clientSystem = clientGo.AddComponent<SyncPositionSystem>();

            serverSystem.Server = server;
            serverSystem.Awake();

            clientSystem.Client = client;
            clientSystem.Awake();
        }

        [UnityTest]
        public IEnumerator SyncPositionFromServerToClient()
        {
            var positions = new Vector3[] {
                new Vector3(1, 2, 3),
                new Vector3(2, 2, 3),
                new Vector3(2, 3, 5),
                new Vector3(2, 3, 5),
            };

            foreach (Vector3 position in positions)
            {
                serverComponent.transform.position = position;
                // wait more than needed to check end position is reached
                yield return new WaitForSeconds(0.5f);

                Assert.That(clientComponent.transform.position, Is.EqualTo(position));
            }
        }
    }
}
