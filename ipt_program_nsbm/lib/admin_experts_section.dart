import 'dart:convert';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'welcome_screen.dart';
import 'package:http/http.dart' as http;

class AdminExpertsSection extends StatefulWidget {
  AdminExpertsSection({this.ipAddressText});
  final String ipAddressText;

  @override
  _AdminExpertsSectionState createState() => _AdminExpertsSectionState();
}

class _AdminExpertsSectionState extends State<AdminExpertsSection> {
  List data;
  int _selectedIndex = 0;

  Future<String> getData() async {
    var response = await http.get(sendIpAddress() + "/getAllItems_mobile");

    this.setState(() {
      data = json.decode(response.body);
    });
    print(data[0]["title"]);
    return "Success!";
  }

  static const TextStyle optionStyle =
      TextStyle(fontSize: 30, fontWeight: FontWeight.bold);
  static const List<Widget> _widgetOptions = <Widget>[
    Text(
      'All Experts list comes here',
      style: optionStyle,
    ),
    Text(
      'Un-approved Experts name list comes here',
      style: optionStyle,
    ),
  ];

  void _onItemTapped(int index) {
    setState(() {
      _selectedIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('BottomNavigationBar Sample'),
      ),
      body: Center(
        child: _widgetOptions.elementAt(_selectedIndex),
      ),
      bottomNavigationBar: BottomNavigationBar(
        items: const <BottomNavigationBarItem>[
          BottomNavigationBarItem(
            icon: Icon(Icons.list),
            title: Text('View All Experts'),
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.playlist_add),
            title: Text('un-approved Experts'),
          ),
        ],
        currentIndex: _selectedIndex,
        selectedItemColor: Colors.amber[800],
        onTap: _onItemTapped,
      ),
    );
  }
}
