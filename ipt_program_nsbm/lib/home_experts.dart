import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'welcome_screen.dart';

class ExpertsHome extends StatefulWidget {
  ExpertsHome({this.ipAddressText});
  final String ipAddressText;

  @override
  _ExpertsHomeState createState() => _ExpertsHomeState();
}

class _ExpertsHomeState extends State<ExpertsHome> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: <Widget>[
              Text('IPT Program - NSBM'),
              GestureDetector(
                onTap: () {
                  Navigator.pop(context);
                },
                child: Text('Logout'),
              ),
            ],
          ),
        ),
        body: Column(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: <Widget>[],
        ));
  }
}
