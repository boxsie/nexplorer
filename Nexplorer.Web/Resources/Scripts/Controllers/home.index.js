﻿import $ from 'jquery';
import Vue from 'vue';
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr';
import moment from 'moment';

import blockchainTable from '../Library/blockchainTable';

import '../../Images/nxs-icon.png';

import '../../Style/home.index.scss';

export class HomeViewModel {
    constructor(options) {
        this.vm = new Vue({
            el: '#main',
            data: {
            },
            computed: {
                timestampUtc() {
                    return this.$layoutHub.utcMoment.format("DD/MM HH:mm:ss");
                },
                lastPrice() {
                    return (this.$layoutHub.latestPrice.last ? this.$layoutHub.latestPrice.last : 0).toFixed(8);
                },
                spread() {
                    return (this.$layoutHub.latestPrice.ask ? (this.$layoutHub.latestPrice.ask - this.$layoutHub.latestPrice.bid) : 0).toFixed(8);
                },
                volume() {
                    return (this.$layoutHub.latestPrice.baseVolume ? this.$layoutHub.latestPrice.baseVolume : 0).toFixed(8);
                }
            },
            components: {
                BlockTable: blockchainTable('blocks'),
                TxTable: blockchainTable('transactions')
            },
            mounted() {
                this.connection = new HubConnectionBuilder()
                    .configureLogging(LogLevel.Information)
                    .withUrl('/homehub').build();

                this.connection.on('newBlockPubSub',
                    (blockData) => {
                        var jsonBlockData = JSON.parse(blockData);
                        this.$refs.blockTable.addItem(jsonBlockData.block);
                        document.title = `#${jsonBlockData.block.height} | Nexplorer - A Nexus Block Explorer`;
                    });

                this.connection.on('newTxPubSub',
                    (tx) => {
                        this.$refs.txTable.addItem(JSON.parse(tx));
                    });
                
                this.connection.start()
                    .then(() => {
                    });
            },
            methods: {
                formatTimeStamp(timestamp) {
                    return timestamp.format("DD/MM HH:mm:ss");
                }
            }
        });
    }
}
