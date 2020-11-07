﻿using OOODamage.BackEnd;
using OOODamage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOODamage.Repositories
{
    class ClientRep : ModelRep
    {

        public void RemoveClient(Client client)
        {
            context.Clients.Remove(client);
            SaveChanges();
        }

        public void AddClient(Client client)
        {
            /*
            if (client.Photo != null)
            {
                client.IdPhoto = AddPhotoForClient(client.Photo);
            }
            else
            {
                client.Photo = "null";
            } 
            */
                    
            client.RegDate = DateTime.Now; 
            //context.Clients.First().
            context.Clients.Add(client);
            SaveChanges();
        }

        public int AddPhotoForClient(string path)
        {
            ClientPhoto clientPhoto = new ClientPhoto();
            clientPhoto.Photo = Utilities.ConvertImageToByte(path);
            context.ClientPhotoes.Add(clientPhoto);
            SaveChanges();
            int idNewPhoto = context.ClientPhotoes.ToList().Max().IdClientPhoto;
            return idNewPhoto; 
        }

        public void EditClient(Client client)
        {
            var baseClient = context.Clients.Where(i => i.IdClient == client.IdClient).FirstOrDefault();
            baseClient = client;
            SaveChanges();
        }

    }
}
