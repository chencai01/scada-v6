﻿// Copyright (c) Rapid Software LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Xml;

namespace Scada.Comm.Drivers.DrvOpcUa.Config
{
    /// <summary>
    /// Represents a subscription configuration.
    /// <para>Представляет конфигурацию подписки.</para>
    /// </summary>
    public class SubscriptionConfig
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public SubscriptionConfig()
        {
            Active = true;
            DisplayName = "";
            PublishingInterval = 1000;
            Items = new List<ItemConfig>();
        }


        /// <summary>
        /// Gets or sets a value indicating that the subscription is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the publishing interval.
        /// </summary>
        public int PublishingInterval { get; set; }

        /// <summary>
        /// Gets the monitored items of the subscription.
        /// </summary>
        public List<ItemConfig> Items { get; private set; }


        /// <summary>
        /// Loads the configuration from the XML node.
        /// </summary>
        public void LoadFromXml(XmlElement xmlElem)
        {
            if (xmlElem == null)
                throw new ArgumentNullException(nameof(xmlElem));

            Active = xmlElem.GetAttrAsBool("active");
            DisplayName = xmlElem.GetAttrAsString("displayName");
            PublishingInterval = xmlElem.GetAttrAsInt("publishingInterval", PublishingInterval);

            foreach (XmlElement itemElem in xmlElem.SelectNodes("Item"))
            {
                ItemConfig itemConfig = new ItemConfig();
                itemConfig.LoadFromXml(itemElem);
                Items.Add(itemConfig);
            }
        }

        /// <summary>
        /// Saves the configuration into the XML node.
        /// </summary>
        public void SaveToXml(XmlElement xmlElem)
        {
            if (xmlElem == null)
                throw new ArgumentNullException(nameof(xmlElem));

            xmlElem.SetAttribute("active", Active);
            xmlElem.SetAttribute("displayName", DisplayName);
            xmlElem.SetAttribute("publishingInterval", PublishingInterval);

            foreach (ItemConfig itemConfig in Items)
            {
                itemConfig.SaveToXml(xmlElem.AppendElem("Item"));
            }
        }
    }
}
