﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nexplorer.Data.Context;

namespace Nexplorer.Data.Migrations
{
    [DbContext(typeof(NexusDb))]
    [Migration("20190323201053_SizeDiffBlockIndex")]
    partial class SizeDiffBlockIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nexplorer.Domain.Entity.Blockchain.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstBlockHeight");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("AddressId");

                    b.HasIndex("FirstBlockHeight");

                    b.HasIndex("Hash");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Nexplorer.Domain.Entity.Blockchain.AddressAggregate", b =>
                {
                    b.Property<int>("AddressId");

                    b.Property<double>("Balance");

                    b.Property<int>("LastBlockHeight");

                    b.Property<double>("ReceivedAmount");

                    b.Property<int>("ReceivedCount");

                    b.Property<double>("SentAmount");

                    b.Property<int>("SentCount");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("AddressId");

                    b.HasIndex("Balance");

                    b.HasIndex("LastBlockHeight");

                    b.ToTable("AddressAggregate");
                });

            modelBuilder.Entity("Nexplorer.Domain.Entity.Blockchain.Block", b =>
                {
                    b.Property<int>("Height");

                    b.Property<string>("Bits")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("Channel");

                    b.Property<double>("Difficulty");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("MerkleRoot")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<double>("Mint");

                    b.Property<double>("Nonce");

                    b.Property<int>("Size");

                    b.Property<DateTime>("Timestamp");

                    b.Property<int>("Version");

                    b.HasKey("Height");

                    b.HasIndex("Channel");

                    b.HasIndex("Difficulty");

                    b.HasIndex("Hash");

                    b.HasIndex("Size");

                    b.HasIndex("Timestamp");

                    b.ToTable("Block");
                });

            modelBuilder.Entity("Nexplorer.Domain.Entity.Blockchain.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<int>("BlockHeight");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<DateTime>("Timestamp");

                    b.Property<int?>("TransactionType");

                    b.HasKey("TransactionId");

                    b.HasIndex("Amount");

                    b.HasIndex("BlockHeight");

                    b.HasIndex("Hash");

                    b.HasIndex("Timestamp");

                    b.HasIndex("TransactionType");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("Nexplorer.Domain.Entity.Blockchain.TransactionInputOutput", b =>
                {
                    b.Property<int>("TransactionInputOutputId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<double>("Amount");

                    b.Property<int>("TransactionId");

                    b.Property<int>("TransactionInputOutputType");

                    b.HasKey("TransactionInputOutputId");

                    b.HasIndex("AddressId");

                    b.HasIndex("Amount");

                    b.HasIndex("TransactionId");

                    b.HasIndex("TransactionInputOutputType");

                    b.ToTable("TransactionInputOutput");
                });

            modelBuilder.Entity("Nexplorer.Domain.Entity.Blockchain.TrustKey", b =>
                {
                    b.Property<int>("TrustKeyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("GenesisHeight");

                    b.Property<string>("Hash")
                        .IsRequired();

                    b.Property<string>("Key")
                        .IsRequired();

                    b.Property<int>("TransactionId");

                    b.HasKey("TrustKeyId");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("GenesisHeight");

                    b.HasIndex("TransactionId");

                    b.ToTable("TrustKey");
                });

            modelBuilder.Entity("Nexplorer.Domain.Entity.Exchange.BittrexSummary", b =>
                {
                    b.Property<int>("BittrexSummaryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Ask");

                    b.Property<double>("BaseVolume");

                    b.Property<double>("Bid");

                    b.Property<double>("Last");

                    b.Property<string>("MarketName")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("OpenBuyOrders");

                    b.Property<int>("OpenSellOrders");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<double>("Volume");

                    b.HasKey("BittrexSummaryId");

                    b.ToTable("BittrexSummary");
                });

            modelBuilder.Entity("Nexplorer.Domain.Entity.Orphan.OrphanBlock", b =>
                {
                    b.Property<int>("BlockId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("Height");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("BlockId");

                    b.ToTable("OrphanBlock");
                });

            modelBuilder.Entity("Nexplorer.Domain.Entity.Orphan.OrphanTransaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlockHeight");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("TransactionId");

                    b.HasIndex("BlockHeight");

                    b.ToTable("OrphanTransaction");
                });

            modelBuilder.Entity("Nexplorer.Domain.Entity.Blockchain.Address", b =>
                {
                    b.HasOne("Nexplorer.Domain.Entity.Blockchain.Block", "FirstBlock")
                        .WithMany()
                        .HasForeignKey("FirstBlockHeight")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Nexplorer.Domain.Entity.Blockchain.AddressAggregate", b =>
                {
                    b.HasOne("Nexplorer.Domain.Entity.Blockchain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Nexplorer.Domain.Entity.Blockchain.Block", "LastBlock")
                        .WithMany()
                        .HasForeignKey("LastBlockHeight")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Nexplorer.Domain.Entity.Blockchain.Transaction", b =>
                {
                    b.HasOne("Nexplorer.Domain.Entity.Blockchain.Block", "Block")
                        .WithMany("Transactions")
                        .HasForeignKey("BlockHeight")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Nexplorer.Domain.Entity.Blockchain.TransactionInputOutput", b =>
                {
                    b.HasOne("Nexplorer.Domain.Entity.Blockchain.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Nexplorer.Domain.Entity.Blockchain.Transaction", "Transaction")
                        .WithMany("InputOutputs")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Nexplorer.Domain.Entity.Blockchain.TrustKey", b =>
                {
                    b.HasOne("Nexplorer.Domain.Entity.Blockchain.Address", "Address")
                        .WithOne()
                        .HasForeignKey("Nexplorer.Domain.Entity.Blockchain.TrustKey", "AddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Nexplorer.Domain.Entity.Blockchain.Block", "GenesisBlock")
                        .WithMany()
                        .HasForeignKey("GenesisHeight")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Nexplorer.Domain.Entity.Blockchain.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Nexplorer.Domain.Entity.Orphan.OrphanTransaction", b =>
                {
                    b.HasOne("Nexplorer.Domain.Entity.Orphan.OrphanBlock", "OrphanBlock")
                        .WithMany("Transactions")
                        .HasForeignKey("BlockHeight")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
