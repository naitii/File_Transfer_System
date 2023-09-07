# File Transfer System (FTS) - Sender and Receiver Applications

## Table of Contents
- [Introduction](#introduction)
- [Prerequisites](#prerequisites)
- [Setup](#setup)
  - [Sender Application](#sender-application)
  - [Receiver Application](#receiver-application)
- [Usage](#usage)

## Introduction
This repository contains two applications: the Sender Application and the Receiver Application, designed for transferring files over a network. These applications are built using C# and WPF.

## Prerequisites
NOTE: This is for only those who want to contribute to the project.

Before setting up the sender and receiver applications, ensure you have **.NET Framework**: Since Both applications are built using .NET Framework.

## Setup
Follow these steps to set up the Sender and Receiver Applications.

Clone or download this repository to your local machine.

### Sender Application
1. Open the Sender Application project by going to File_Transfer_System\FTS(sender)\

2. Run the FTS(sender).exe.

3. Login by writing your institute email ID.

4. Enter the IP address of the receiver's machine in the "IP Address" field.

5. Click the "SELECT FILES TO SEND" button to select files for transfer.

6. Click the "SEND FILES" button to send files to the Receiver Application.

### Receiver Application

1. Open the Receiver Application project by going to File_Transfer_System\FTS(receiver)\

2. Run the FTS(receiver).exe.
3. Login by writing your institute email ID.

4. The Receiver Application will display your local IP address. Make a note of it; you will need it for the Sender Application setup.

5. You need to select the folder where you want to receive the files by clicking on "SELECT FOLDER" button.

## Usage
1. Start both the Sender and Receiver Applications following the setup instructions.

2. In the Sender Application, enter the IP address of the receiver's machine.

3. Select the file to send. NOTE: Make sure that file you are sending doesn't contains any illegal characters such as spaces.

4. Click the "Transfer" button to initiate the file transfer.

5. The Receiver Application will receive the files and save them to the specified folder.
