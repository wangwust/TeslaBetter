/*
Navicat MySQL Data Transfer

Source Server         : 阿里云【Mysql】
Source Server Version : 50724
Source Host           : 47.98.115.91:3306
Source Database       : tesla

Target Server Type    : MYSQL
Target Server Version : 50724
File Encoding         : 65001

Date: 2018-11-21 12:19:16
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for app_betorder
-- ----------------------------
DROP TABLE IF EXISTS `app_betorder`;
CREATE TABLE `app_betorder` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CreateTime` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `CreateTimestamp` bigint(20) DEFAULT NULL,
  `UserName` varchar(50) DEFAULT NULL COMMENT '用户名',
  `TaskId` int(11) DEFAULT NULL,
  `TaskName` varchar(50) DEFAULT NULL,
  `LotteryName` varchar(32) DEFAULT NULL COMMENT '彩种名称',
  `Issue` bigint(32) DEFAULT NULL,
  `Number` varchar(255) DEFAULT NULL COMMENT '投注号码',
  `SingleMoney` decimal(11,2) DEFAULT '0.00' COMMENT '单注金额',
  `TotalMoney` decimal(11,2) DEFAULT '0.00' COMMENT '投注总额',
  `BeforeBalance` decimal(11,2) DEFAULT '0.00',
  `AfterBalance` decimal(11,2) DEFAULT '0.00',
  `Source` tinyint(4) DEFAULT NULL COMMENT '来源。1：服务端，2：客户端',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=82 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for app_betparam
-- ----------------------------
DROP TABLE IF EXISTS `app_betparam`;
CREATE TABLE `app_betparam` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CreateTime` datetime DEFAULT NULL,
  `TaskId` int(11) DEFAULT NULL,
  `TaskName` varchar(50) DEFAULT NULL,
  `Params` text COMMENT '投注参数',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of app_betparam
-- ----------------------------

-- ----------------------------
-- Table structure for app_charge
-- ----------------------------
DROP TABLE IF EXISTS `app_charge`;
CREATE TABLE `app_charge` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CreateTime` datetime DEFAULT NULL,
  `UpdateTime` datetime DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Way` varchar(50) DEFAULT NULL,
  `Money` decimal(11,2) DEFAULT '0.00',
  `IsDeleted` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for app_log
-- ----------------------------
DROP TABLE IF EXISTS `app_log`;
CREATE TABLE `app_log` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CreateTime` datetime DEFAULT NULL,
  `CreateTimestamp` bigint(20) DEFAULT NULL,
  `UserName` varchar(50) DEFAULT NULL COMMENT '用户',
  `TaskId` int(11) DEFAULT NULL COMMENT '任务ID',
  `TaskName` varchar(50) DEFAULT NULL COMMENT '任务名称',
  `Source` tinyint(4) DEFAULT '0' COMMENT '日志来源。0：未知，1：服务端；2：客户端',
  `Type` varchar(16) DEFAULT NULL,
  `TypeText` varchar(16) DEFAULT NULL,
  `Message` varchar(4000) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=93 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for app_task
-- ----------------------------
DROP TABLE IF EXISTS `app_task`;
CREATE TABLE `app_task` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CreateTime` datetime DEFAULT NULL,
  `UpdateTime` datetime DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL COMMENT '任务名称',
  `StartHour` int(11) DEFAULT '8' COMMENT '每天开始执行的准点数',
  `EndHour` int(11) DEFAULT '23' COMMENT '每天结束执行的准点数',
  `SingleMoney` decimal(10,0) DEFAULT '2' COMMENT '单注金额',
  `ServerCode` varchar(50) DEFAULT NULL COMMENT '服务端平台代码',
  `ServerApi` varchar(255) DEFAULT NULL COMMENT '服务端接口地址',
  `ServerUserName` varchar(255) DEFAULT NULL COMMENT '服务端用户名',
  `ServerUserPwd` varchar(255) DEFAULT NULL COMMENT '服务端用户密码',
  `ServerDeviceType` varchar(50) DEFAULT 'IOS' COMMENT '服务端设备类型',
  `ServerIP` varchar(50) DEFAULT NULL COMMENT '服务端IP',
  `ServerMaxNumCount` int(11) DEFAULT '0' COMMENT '服务端投注的号码个数上限。取值范围1-49',
  `ServerMinNumCount` int(11) DEFAULT '0' COMMENT '服务端号码个数下限。取值范围1-49',
  `ClientCode` varchar(50) DEFAULT NULL COMMENT '客户端平台代码',
  `ClientApi` varchar(255) DEFAULT NULL COMMENT '客户端接口地址',
  `ClientUserName` varchar(255) DEFAULT NULL COMMENT '客户端用户名',
  `ClientUserPwd` varchar(255) DEFAULT NULL COMMENT '客户端用户密码',
  `ClientDeviceType` varchar(50) DEFAULT 'Android' COMMENT '客户端设备名称',
  `ClientIP` varchar(50) DEFAULT NULL COMMENT '客户端IP',
  `LastStopReason` tinyint(4) DEFAULT NULL COMMENT '上次任务停止的原因。0：未启动；1：服务端掉线；2：服务端余额不足；3：服务端投注异常；4：客户端掉线；5：客户端余额不足；6：客户端投注异常；7：手动停止',
  `State` tinyint(4) DEFAULT '0' COMMENT '任务状态。0：停止；1：开启',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of app_task
-- ----------------------------
INSERT INTO `app_task` VALUES ('1', '2018-11-12 12:14:04', '2018-11-21 00:01:11', '任务1', '0', '24', '10', 'YLC', 'https://api.ylcjiekou.com', 'litaibai999', 'litaibai999.', 'IOS', '110.87.24.111', '49', '49', 'V8', 'https://api.v8jiekou.com', 'chenhuo88', 'chenhuo88.', 'Android', '116.255.250.156', '5', '1');

-- ----------------------------
-- Table structure for app_withdraw
-- ----------------------------
DROP TABLE IF EXISTS `app_withdraw`;
CREATE TABLE `app_withdraw` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CreateTime` datetime DEFAULT NULL,
  `UpdateTime` datetime DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Way` varchar(50) DEFAULT NULL,
  `Money` decimal(11,2) DEFAULT '0.00',
  `IsDeleted` tinyint(4) DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of app_withdraw
-- ----------------------------

-- ----------------------------
-- Table structure for sys_area
-- ----------------------------
DROP TABLE IF EXISTS `sys_area`;
CREATE TABLE `sys_area` (
  `F_Id` varchar(50) NOT NULL COMMENT '主键',
  `F_ParentId` varchar(50) DEFAULT NULL COMMENT '父级',
  `F_Layers` int(11) DEFAULT NULL COMMENT '层次',
  `F_EnCode` varchar(50) DEFAULT NULL COMMENT '编码',
  `F_FullName` varchar(50) DEFAULT NULL COMMENT '名称',
  `F_SimpleSpelling` varchar(50) DEFAULT NULL COMMENT '简拼',
  `F_SortCode` int(11) DEFAULT NULL COMMENT '排序码',
  `F_DeleteMark` tinyint(4) DEFAULT NULL COMMENT '删除标志',
  `F_EnabledMark` tinyint(4) DEFAULT NULL COMMENT '有效标志',
  `F_Description` text COMMENT '描述',
  `F_CreatorTime` datetime DEFAULT NULL COMMENT '创建日期',
  `F_CreatorUserId` varchar(50) DEFAULT NULL COMMENT '创建用户主键',
  `F_LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `F_LastModifyUserId` varchar(50) DEFAULT NULL COMMENT '最后修改用户',
  `F_DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  `F_DeleteUserId` varchar(50) DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`F_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='行政区域表';

-- ----------------------------
-- Records of sys_area
-- ----------------------------
INSERT INTO `sys_area` VALUES ('110000', '0', '0', null, '北京', null, '110000', null, '1', '&nbsp;', '2016-07-20 00:00:00', null, '2018-11-05 17:52:06', 'c849af75-919c-4940-b93e-7728ab73c1f3', null, null);
INSERT INTO `sys_area` VALUES ('110100', '110000', '0', null, '北京市', null, '110100', null, '1', '&nbsp;', '2016-07-20 00:00:00', null, '2018-11-05 17:51:54', 'c849af75-919c-4940-b93e-7728ab73c1f3', null, null);
INSERT INTO `sys_area` VALUES ('120000', '0', '1', '120000', '天津', 'tj', '120000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('120100', '120000', '2', '120100', '天津市', 'tjs', '120100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('130000', '0', '1', '130000', '河北省', 'hbs', '130000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('130100', '130000', '2', '130100', '石家庄市', 'sjzs', '130100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('130200', '130000', '2', '130200', '唐山市', 'tss', '130200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('130300', '130000', '2', '130300', '秦皇岛市', 'qhds', '130300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('130400', '130000', '2', '130400', '邯郸市', 'hds', '130400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('130500', '130000', '2', '130500', '邢台市', 'xts', '130500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('130600', '130000', '2', '130600', '保定市', 'bds', '130600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('130700', '130000', '2', '130700', '张家口市', 'zjks', '130700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('130800', '130000', '2', '130800', '承德市', 'cds', '130800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('130900', '130000', '2', '130900', '沧州市', 'czs', '130900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('131000', '130000', '2', '131000', '廊坊市', 'lfs', '131000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('131100', '130000', '2', '131100', '衡水市', 'hss', '131100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('140000', '0', '1', '140000', '山西省', 'sxs', '140000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('140100', '140000', '2', '140100', '太原市', 'tys', '140100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('140200', '140000', '2', '140200', '大同市', 'dts', '140200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('140300', '140000', '2', '140300', '阳泉市', 'yqs', '140300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('140400', '140000', '2', '140400', '长治市', 'czs', '140400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('140500', '140000', '2', '140500', '晋城市', 'jcs', '140500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('140600', '140000', '2', '140600', '朔州市', 'szs', '140600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('140700', '140000', '2', '140700', '晋中市', 'jzs', '140700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('140800', '140000', '2', '140800', '运城市', 'ycs', '140800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('140900', '140000', '2', '140900', '忻州市', 'xzs', '140900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('141000', '140000', '2', '141000', '临汾市', 'lfs', '141000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('141100', '140000', '2', '141100', '吕梁市', 'lls', '141100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('150000', '0', '1', '150000', '内蒙古自治区', 'nmgzzq', '150000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('150100', '150000', '2', '150100', '呼和浩特市', 'hhhts', '150100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('150200', '150000', '2', '150200', '包头市', 'bts', '150200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('150300', '150000', '2', '150300', '乌海市', 'whs', '150300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('150400', '150000', '2', '150400', '赤峰市', 'cfs', '150400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('150500', '150000', '2', '150500', '通辽市', 'tls', '150500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('150600', '150000', '2', '150600', '鄂尔多斯市', 'eedss', '150600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('150700', '150000', '2', '150700', '呼伦贝尔市', 'hlbes', '150700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('150800', '150000', '2', '150800', '巴彦淖尔市', 'bynes', '150800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('150900', '150000', '2', '150900', '乌兰察布市', 'wlcbs', '150900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('152200', '150000', '2', '152200', '兴安盟', 'xam', '152200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('152500', '150000', '2', '152500', '锡林郭勒盟', 'xlglm', '152500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('152900', '150000', '2', '152900', '阿拉善盟', 'alsm', '152900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('210000', '0', '1', '210000', '辽宁省', 'lns', '210000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('210100', '210000', '2', '210100', '沈阳市', 'sys', '210100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('210200', '210000', '2', '210200', '大连市', 'dls', '210200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('210300', '210000', '2', '210300', '鞍山市', 'ass', '210300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('210400', '210000', '2', '210400', '抚顺市', 'fss', '210400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('210500', '210000', '2', '210500', '本溪市', 'bxs', '210500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('210600', '210000', '2', '210600', '丹东市', 'dds', '210600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('210700', '210000', '2', '210700', '锦州市', 'jzs', '210700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('210800', '210000', '2', '210800', '营口市', 'yks', '210800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('210900', '210000', '2', '210900', '阜新市', 'fxs', '210900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('211000', '210000', '2', '211000', '辽阳市', 'lys', '211000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('211100', '210000', '2', '211100', '盘锦市', 'pjs', '211100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('211200', '210000', '2', '211200', '铁岭市', 'tls', '211200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('211300', '210000', '2', '211300', '朝阳市', 'zys', '211300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('211400', '210000', '2', '211400', '葫芦岛市', 'hlds', '211400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('220000', '0', '1', '220000', '吉林省', 'jls', '220000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('220100', '220000', '2', '220100', '长春市', 'zcs', '220100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('220200', '220000', '2', '220200', '吉林市', 'jls', '220200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('220300', '220000', '2', '220300', '四平市', 'sps', '220300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('220400', '220000', '2', '220400', '辽源市', 'lys', '220400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('220500', '220000', '2', '220500', '通化市', 'ths', '220500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('220600', '220000', '2', '220600', '白山市', 'bss', '220600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('220700', '220000', '2', '220700', '松原市', 'sys', '220700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('220800', '220000', '2', '220800', '白城市', 'bcs', '220800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('222400', '220000', '2', '222400', '延边朝鲜族自治州', 'ybzxzzzz', '222400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('230000', '0', '1', '230000', '黑龙江省', 'hljs', '230000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('230100', '230000', '2', '230100', '哈尔滨市', 'hebs', '230100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('230200', '230000', '2', '230200', '齐齐哈尔市', 'qqhes', '230200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('230300', '230000', '2', '230300', '鸡西市', 'jxs', '230300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('230400', '230000', '2', '230400', '鹤岗市', 'hgs', '230400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('230500', '230000', '2', '230500', '双鸭山市', 'syss', '230500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('230600', '230000', '2', '230600', '大庆市', 'dqs', '230600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('230700', '230000', '2', '230700', '伊春市', 'ycs', '230700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('230800', '230000', '2', '230800', '佳木斯市', 'jmss', '230800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('230900', '230000', '2', '230900', '七台河市', 'qths', '230900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('231000', '230000', '2', '231000', '牡丹江市', 'mdjs', '231000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('231100', '230000', '2', '231100', '黑河市', 'hhs', '231100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('231200', '230000', '2', '231200', '绥化市', 'shs', '231200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('232700', '230000', '2', '232700', '大兴安岭地区', 'dxaldq', '232700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('310000', '0', '1', '310000', '上海', 'sh', '310000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('310100', '310000', '2', '310100', '上海市', 'shs', '310100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('320000', '0', '1', '320000', '江苏省', 'jss', '320000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('320100', '320000', '2', '320100', '南京市', 'njs', '320100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('320200', '320000', '2', '320200', '无锡市', 'wxs', '320200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('320300', '320000', '2', '320300', '徐州市', 'xzs', '320300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('320400', '320000', '2', '320400', '常州市', 'czs', '320400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('320500', '320000', '2', '320500', '苏州市', 'szs', '320500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('320600', '320000', '2', '320600', '南通市', 'nts', '320600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('320700', '320000', '2', '320700', '连云港市', 'lygs', '320700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('320800', '320000', '2', '320800', '淮安市', 'has', '320800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('320900', '320000', '2', '320900', '盐城市', 'ycs', '320900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('321000', '320000', '2', '321000', '扬州市', 'yzs', '321000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('321100', '320000', '2', '321100', '镇江市', 'zjs', '321100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('321200', '320000', '2', '321200', '泰州市', 'tzs', '321200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('321300', '320000', '2', '321300', '宿迁市', 'sqs', '321300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('330000', '0', '1', '330000', '浙江省', 'zjs', '330000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('330100', '330000', '2', '330100', '杭州市', 'hzs', '330100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('330200', '330000', '2', '330200', '宁波市', 'nbs', '330200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('330300', '330000', '2', '330300', '温州市', 'wzs', '330300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('330400', '330000', '2', '330400', '嘉兴市', 'jxs', '330400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('330500', '330000', '2', '330500', '湖州市', 'hzs', '330500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('330600', '330000', '2', '330600', '绍兴市', 'sxs', '330600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('330700', '330000', '2', '330700', '金华市', 'jhs', '330700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('330800', '330000', '2', '330800', '衢州市', 'qzs', '330800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('330900', '330000', '2', '330900', '舟山市', 'zss', '330900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('331000', '330000', '2', '331000', '台州市', 'tzs', '331000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('331100', '330000', '2', '331100', '丽水市', 'lss', '331100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('340000', '0', '1', '340000', '安徽省', 'ahs', '340000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('340100', '340000', '2', '340100', '合肥市', 'hfs', '340100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('340200', '340000', '2', '340200', '芜湖市', 'whs', '340200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('340300', '340000', '2', '340300', '蚌埠市', 'bbs', '340300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('340400', '340000', '2', '340400', '淮南市', 'hns', '340400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('340500', '340000', '2', '340500', '马鞍山市', 'mass', '340500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('340600', '340000', '2', '340600', '淮北市', 'hbs', '340600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('340700', '340000', '2', '340700', '铜陵市', 'tls', '340700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('340800', '340000', '2', '340800', '安庆市', 'aqs', '340800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('341000', '340000', '2', '341000', '黄山市', 'hss', '341000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('341100', '340000', '2', '341100', '滁州市', 'czs', '341100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('341200', '340000', '2', '341200', '阜阳市', 'fys', '341200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('341300', '340000', '2', '341300', '宿州市', 'szs', '341300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('341500', '340000', '2', '341500', '六安市', 'las', '341500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('341600', '340000', '2', '341600', '亳州市', 'bzs', '341600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('341700', '340000', '2', '341700', '池州市', 'czs', '341700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('341800', '340000', '2', '341800', '宣城市', 'xcs', '341800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('350000', '0', '1', '350000', '福建省', 'fjs', '350000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('350100', '350000', '2', '350100', '福州市', 'fzs', '350100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('350200', '350000', '2', '350200', '厦门市', 'xms', '350200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('350300', '350000', '2', '350300', '莆田市', 'pts', '350300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('350400', '350000', '2', '350400', '三明市', 'sms', '350400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('350500', '350000', '2', '350500', '泉州市', 'qzs', '350500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('350600', '350000', '2', '350600', '漳州市', 'zzs', '350600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('350700', '350000', '2', '350700', '南平市', 'nps', '350700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('350800', '350000', '2', '350800', '龙岩市', 'lys', '350800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('350900', '350000', '2', '350900', '宁德市', 'nds', '350900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('360000', '0', '1', '360000', '江西省', 'jxs', '360000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('360100', '360000', '2', '360100', '南昌市', 'ncs', '360100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('360200', '360000', '2', '360200', '景德镇市', 'jdzs', '360200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('360300', '360000', '2', '360300', '萍乡市', 'pxs', '360300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('360400', '360000', '2', '360400', '九江市', 'jjs', '360400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('360500', '360000', '2', '360500', '新余市', 'xys', '360500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('360600', '360000', '2', '360600', '鹰潭市', 'yts', '360600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('360700', '360000', '2', '360700', '赣州市', 'gzs', '360700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('360800', '360000', '2', '360800', '吉安市', 'jas', '360800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('360900', '360000', '2', '360900', '宜春市', 'ycs', '360900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('361000', '360000', '2', '361000', '抚州市', 'fzs', '361000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('361100', '360000', '2', '361100', '上饶市', 'srs', '361100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('370000', '0', '1', '370000', '山东省', 'sds', '370000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('370100', '370000', '2', '370100', '济南市', 'jns', '370100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('370200', '370000', '2', '370200', '青岛市', 'qds', '370200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('370300', '370000', '2', '370300', '淄博市', 'zbs', '370300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('370400', '370000', '2', '370400', '枣庄市', 'zzs', '370400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('370500', '370000', '2', '370500', '东营市', 'dys', '370500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('370600', '370000', '2', '370600', '烟台市', 'yts', '370600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('370700', '370000', '2', '370700', '潍坊市', 'wfs', '370700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('370800', '370000', '2', '370800', '济宁市', 'jns', '370800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('370900', '370000', '2', '370900', '泰安市', 'tas', '370900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('371000', '370000', '2', '371000', '威海市', 'whs', '371000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('371100', '370000', '2', '371100', '日照市', 'rzs', '371100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('371200', '370000', '2', '371200', '莱芜市', 'lws', '371200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('371300', '370000', '2', '371300', '临沂市', 'lys', '371300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('371400', '370000', '2', '371400', '德州市', 'dzs', '371400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('371500', '370000', '2', '371500', '聊城市', 'lcs', '371500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('371600', '370000', '2', '371600', '滨州市', 'bzs', '371600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('371700', '370000', '2', '371700', '菏泽市', 'hzs', '371700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('410000', '0', '1', '410000', '河南省', 'hns', '410000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('410100', '410000', '2', '410100', '郑州市', 'zzs', '410100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('410200', '410000', '2', '410200', '开封市', 'kfs', '410200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('410300', '410000', '2', '410300', '洛阳市', 'lys', '410300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('410400', '410000', '2', '410400', '平顶山市', 'pdss', '410400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('410500', '410000', '2', '410500', '安阳市', 'ays', '410500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('410600', '410000', '2', '410600', '鹤壁市', 'hbs', '410600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('410700', '410000', '2', '410700', '新乡市', 'xxs', '410700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('410800', '410000', '2', '410800', '焦作市', 'jzs', '410800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('410881', '410000', '2', '410881', '济源市', 'jys', '410881', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('410900', '410000', '2', '410900', '濮阳市', 'pys', '410900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('411000', '410000', '2', '411000', '许昌市', 'xcs', '411000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('411100', '410000', '2', '411100', '漯河市', 'lhs', '411100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('411200', '410000', '2', '411200', '三门峡市', 'smxs', '411200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('411300', '410000', '2', '411300', '南阳市', 'nys', '411300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('411400', '410000', '2', '411400', '商丘市', 'sqs', '411400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('411500', '410000', '2', '411500', '信阳市', 'xys', '411500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('411600', '410000', '2', '411600', '周口市', 'zks', '411600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('411700', '410000', '2', '411700', '驻马店市', 'zmds', '411700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('420000', '0', '1', '420000', '湖北省', 'hbs', '420000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('420100', '420000', '2', '420100', '武汉市', 'whs', '420100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('420200', '420000', '2', '420200', '黄石市', 'hss', '420200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('420300', '420000', '2', '420300', '十堰市', 'sys', '420300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('420500', '420000', '2', '420500', '宜昌市', 'ycs', '420500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('420600', '420000', '2', '420600', '襄阳市', 'xys', '420600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('420700', '420000', '2', '420700', '鄂州市', 'ezs', '420700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('420800', '420000', '2', '420800', '荆门市', 'jms', '420800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('420900', '420000', '2', '420900', '孝感市', 'xgs', '420900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('421000', '420000', '2', '421000', '荆州市', 'jzs', '421000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('421100', '420000', '2', '421100', '黄冈市', 'hgs', '421100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('421200', '420000', '2', '421200', '咸宁市', 'xns', '421200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('421300', '420000', '2', '421300', '随州市', 'szs', '421300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('422800', '420000', '2', '422800', '恩施土家族苗族自治州', 'estjzmzzzz', '422800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('430000', '0', '1', '430000', '湖南省', 'hns', '430000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('430100', '430000', '2', '430100', '长沙市', 'zss', '430100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('430200', '430000', '2', '430200', '株洲市', 'zzs', '430200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('430300', '430000', '2', '430300', '湘潭市', 'xts', '430300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('430400', '430000', '2', '430400', '衡阳市', 'hys', '430400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('430500', '430000', '2', '430500', '邵阳市', 'sys', '430500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('430600', '430000', '2', '430600', '岳阳市', 'yys', '430600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('430700', '430000', '2', '430700', '常德市', 'cds', '430700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('430800', '430000', '2', '430800', '张家界市', 'zjjs', '430800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('430900', '430000', '2', '430900', '益阳市', 'yys', '430900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('431000', '430000', '2', '431000', '郴州市', 'czs', '431000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('431100', '430000', '2', '431100', '永州市', 'yzs', '431100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('431200', '430000', '2', '431200', '怀化市', 'hhs', '431200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('431300', '430000', '2', '431300', '娄底市', 'lds', '431300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('433100', '430000', '2', '433100', '湘西土家族苗族自治州', 'xxtjzmzzzz', '433100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('440000', '0', '1', '440000', '广东省', 'gds', '440000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('440100', '440000', '2', '440100', '广州市', 'gzs', '440100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('440200', '440000', '2', '440200', '韶关市', 'sgs', '440200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('440300', '440000', '2', '440300', '深圳市', 'szs', '440300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('440400', '440000', '2', '440400', '珠海市', 'zhs', '440400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('440500', '440000', '2', '440500', '汕头市', 'sts', '440500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('440600', '440000', '2', '440600', '佛山市', 'fss', '440600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('440700', '440000', '2', '440700', '江门市', 'jms', '440700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('440800', '440000', '2', '440800', '湛江市', 'zjs', '440800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('440900', '440000', '2', '440900', '茂名市', 'mms', '440900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('441200', '440000', '2', '441200', '肇庆市', 'zqs', '441200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('441300', '440000', '2', '441300', '惠州市', 'hzs', '441300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('441400', '440000', '2', '441400', '梅州市', 'mzs', '441400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('441500', '440000', '2', '441500', '汕尾市', 'sws', '441500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('441600', '440000', '2', '441600', '河源市', 'hys', '441600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('441700', '440000', '2', '441700', '阳江市', 'yjs', '441700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('441800', '440000', '2', '441800', '清远市', 'qys', '441800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('445100', '440000', '2', '445100', '潮州市', 'czs', '445100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('445200', '440000', '2', '445200', '揭阳市', 'jys', '445200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('445300', '440000', '2', '445300', '云浮市', 'yfs', '445300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('450000', '0', '1', '450000', '广西壮族自治区', 'gxzzzzq', '450000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('450100', '450000', '2', '450100', '南宁市', 'nns', '450100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('450200', '450000', '2', '450200', '柳州市', 'lzs', '450200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('450300', '450000', '2', '450300', '桂林市', 'gls', '450300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('450400', '450000', '2', '450400', '梧州市', 'wzs', '450400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('450500', '450000', '2', '450500', '北海市', 'bhs', '450500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('450600', '450000', '2', '450600', '防城港市', 'fcgs', '450600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('450700', '450000', '2', '450700', '钦州市', 'qzs', '450700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('450800', '450000', '2', '450800', '贵港市', 'ggs', '450800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('450900', '450000', '2', '450900', '玉林市', 'yls', '450900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('451000', '450000', '2', '451000', '百色市', 'bss', '451000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('451100', '450000', '2', '451100', '贺州市', 'hzs', '451100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('451200', '450000', '2', '451200', '河池市', 'hcs', '451200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('451300', '450000', '2', '451300', '来宾市', 'lbs', '451300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('451400', '450000', '2', '451400', '崇左市', 'czs', '451400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('460000', '0', '1', '460000', '海南省', 'hns', '460000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('460100', '460000', '2', '460100', '海口市', 'hks', '460100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('500000', '0', '1', '500000', '重庆', 'zq', '500000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('500100', '500000', '2', '500100', '重庆市', 'zqs', '500100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('510000', '0', '1', '510000', '四川省', 'scs', '510000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('510100', '510000', '2', '510100', '成都市', 'cds', '510100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('510300', '510000', '2', '510300', '自贡市', 'zgs', '510300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('510400', '510000', '2', '510400', '攀枝花市', 'pzhs', '510400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('510500', '510000', '2', '510500', '泸州市', 'lzs', '510500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('510600', '510000', '2', '510600', '德阳市', 'dys', '510600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('510700', '510000', '2', '510700', '绵阳市', 'mys', '510700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('510800', '510000', '2', '510800', '广元市', 'gys', '510800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('510900', '510000', '2', '510900', '遂宁市', 'sns', '510900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('511000', '510000', '2', '511000', '内江市', 'njs', '511000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('511100', '510000', '2', '511100', '乐山市', 'yss', '511100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('511300', '510000', '2', '511300', '南充市', 'ncs', '511300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('511400', '510000', '2', '511400', '眉山市', 'mss', '511400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('511500', '510000', '2', '511500', '宜宾市', 'ybs', '511500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('511600', '510000', '2', '511600', '广安市', 'gas', '511600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('511700', '510000', '2', '511700', '达州市', 'dzs', '511700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('511800', '510000', '2', '511800', '雅安市', 'yas', '511800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('511900', '510000', '2', '511900', '巴中市', 'bzs', '511900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('512000', '510000', '2', '512000', '资阳市', 'zys', '512000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('513200', '510000', '2', '513200', '阿坝藏族羌族自治州', 'abzzqzzzz', '513200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('513300', '510000', '2', '513300', '甘孜藏族自治州', 'gzzzzzz', '513300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('513400', '510000', '2', '513400', '凉山彝族自治州', 'lsyzzzz', '513400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('520000', '0', '1', '520000', '贵州省', 'gzs', '520000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('520100', '520000', '2', '520100', '贵阳市', 'gys', '520100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('520200', '520000', '2', '520200', '六盘水市', 'lpss', '520200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('520300', '520000', '2', '520300', '遵义市', 'zys', '520300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('520400', '520000', '2', '520400', '安顺市', 'ass', '520400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('522200', '520000', '2', '522200', '铜仁市', 'trs', '522200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('522300', '520000', '2', '522300', '黔西南布依族苗族自治州', 'qxnbyzmzzzz', '522300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('522400', '520000', '2', '522400', '毕节市', 'bjs', '522400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('522600', '520000', '2', '522600', '黔东南苗族侗族自治州', 'qdnmztzzzz', '522600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('522700', '520000', '2', '522700', '黔南布依族苗族自治州', 'qnbyzmzzzz', '522700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('530000', '0', '1', '530000', '云南省', 'yns', '530000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('530100', '530000', '2', '530100', '昆明市', 'kms', '530100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('530300', '530000', '2', '530300', '曲靖市', 'qjs', '530300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('530400', '530000', '2', '530400', '玉溪市', 'yxs', '530400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('530500', '530000', '2', '530500', '保山市', 'bss', '530500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('530600', '530000', '2', '530600', '昭通市', 'zts', '530600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('530700', '530000', '2', '530700', '丽江市', 'ljs', '530700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('530800', '530000', '2', '530800', '普洱市', 'pes', '530800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('530900', '530000', '2', '530900', '临沧市', 'lcs', '530900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('532300', '530000', '2', '532300', '楚雄彝族自治州', 'cxyzzzz', '532300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('532500', '530000', '2', '532500', '红河哈尼族彝族自治州', 'hhhnzyzzzz', '532500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('532600', '530000', '2', '532600', '文山壮族苗族自治州', 'wszzmzzzz', '532600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('532800', '530000', '2', '532800', '西双版纳傣族自治州', 'xsbndzzzz', '532800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('532900', '530000', '2', '532900', '大理白族自治州', 'dlbzzzz', '532900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('533100', '530000', '2', '533100', '德宏傣族景颇族自治州', 'dhdzjpzzzz', '533100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('533300', '530000', '2', '533300', '怒江傈僳族自治州', 'njlszzzz', '533300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('533400', '530000', '2', '533400', '迪庆藏族自治州', 'dqzzzzz', '533400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('540000', '0', '1', '540000', '西藏自治区', 'xzzzq', '540000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('540100', '540000', '2', '540100', '拉萨市', 'lss', '540100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('542100', '540000', '2', '542100', '昌都地区', 'cddq', '542100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('542200', '540000', '2', '542200', '山南地区', 'sndq', '542200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('542300', '540000', '2', '542300', '日喀则地区', 'rkzdq', '542300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('542400', '540000', '2', '542400', '那曲地区', 'nqdq', '542400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('542500', '540000', '2', '542500', '阿里地区', 'aldq', '542500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('542600', '540000', '2', '542600', '林芝地区', 'lzdq', '542600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('610000', '0', '1', '610000', '陕西省', 'sxs', '610000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('610100', '610000', '2', '610100', '西安市', 'xas', '610100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('610200', '610000', '2', '610200', '铜川市', 'tcs', '610200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('610300', '610000', '2', '610300', '宝鸡市', 'bjs', '610300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('610400', '610000', '2', '610400', '咸阳市', 'xys', '610400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('610500', '610000', '2', '610500', '渭南市', 'wns', '610500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('610600', '610000', '2', '610600', '延安市', 'yas', '610600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('610700', '610000', '2', '610700', '汉中市', 'hzs', '610700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('610800', '610000', '2', '610800', '榆林市', 'yls', '610800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('610900', '610000', '2', '610900', '安康市', 'aks', '610900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('611000', '610000', '2', '611000', '商洛市', 'sls', '611000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('620000', '0', '1', '620000', '甘肃省', 'gss', '620000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('620100', '620000', '2', '620100', '兰州市', 'lzs', '620100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('620200', '620000', '2', '620200', '嘉峪关市', 'jygs', '620200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('620300', '620000', '2', '620300', '金昌市', 'jcs', '620300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('620400', '620000', '2', '620400', '白银市', 'bys', '620400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('620500', '620000', '2', '620500', '天水市', 'tss', '620500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('620600', '620000', '2', '620600', '武威市', 'wws', '620600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('620700', '620000', '2', '620700', '张掖市', 'zys', '620700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('620800', '620000', '2', '620800', '平凉市', 'pls', '620800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('620900', '620000', '2', '620900', '酒泉市', 'jqs', '620900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('621000', '620000', '2', '621000', '庆阳市', 'qys', '621000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('621100', '620000', '2', '621100', '定西市', 'dxs', '621100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('621200', '620000', '2', '621200', '陇南市', 'lns', '621200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('622900', '620000', '2', '622900', '临夏回族自治州', 'lxhzzzz', '622900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('623000', '620000', '2', '623000', '甘南藏族自治州', 'gnzzzzz', '623000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('630000', '0', '1', '630000', '青海省', 'qhs', '630000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('630100', '630000', '2', '630100', '西宁市', 'xns', '630100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('632100', '630000', '2', '632100', '海东市', 'hds', '632100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('632200', '630000', '2', '632200', '海北藏族自治州', 'hbzzzzz', '632200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('632300', '630000', '2', '632300', '黄南藏族自治州', 'hnzzzzz', '632300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('632500', '630000', '2', '632500', '海南藏族自治州', 'hnzzzzz', '632500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('632600', '630000', '2', '632600', '果洛藏族自治州', 'glzzzzz', '632600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('632700', '630000', '2', '632700', '玉树藏族自治州', 'yszzzzz', '632700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('632800', '630000', '2', '632800', '海西蒙古族藏族自治州', 'hxmgzzzzzz', '632800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('640000', '0', '1', '640000', '宁夏回族自治区', 'nxhzzzq', '640000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('640100', '640000', '2', '640100', '银川市', 'ycs', '640100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('640200', '640000', '2', '640200', '石嘴山市', 'szss', '640200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('640300', '640000', '2', '640300', '吴忠市', 'wzs', '640300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('640400', '640000', '2', '640400', '固原市', 'gys', '640400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('640500', '640000', '2', '640500', '中卫市', 'zws', '640500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('650000', '0', '1', '650000', '新疆维吾尔自治区', 'xjwwezzq', '650000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('650100', '650000', '2', '650100', '乌鲁木齐市', 'wlmqs', '650100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('650200', '650000', '2', '650200', '克拉玛依市', 'klmys', '650200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('652100', '650000', '2', '652100', '吐鲁番地区', 'tlfdq', '652100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('652200', '650000', '2', '652200', '哈密地区', 'hmdq', '652200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('652300', '650000', '2', '652300', '昌吉回族自治州', 'cjhzzzz', '652300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('652700', '650000', '2', '652700', '博尔塔拉蒙古自治州', 'betlmgzzz', '652700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('652800', '650000', '2', '652800', '巴音郭楞蒙古自治州', 'byglmgzzz', '652800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('652900', '650000', '2', '652900', '阿克苏地区', 'aksdq', '652900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('653000', '650000', '2', '653000', '克孜勒苏柯尔克孜自治州', 'kzlskekzzzz', '653000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('653100', '650000', '2', '653100', '喀什地区', 'ksdq', '653100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('653200', '650000', '2', '653200', '和田地区', 'htdq', '653200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('654000', '650000', '2', '654000', '伊犁哈萨克自治州', 'ylhskzzz', '654000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('654200', '650000', '2', '654200', '塔城地区', 'tcdq', '654200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('654300', '650000', '2', '654300', '阿勒泰地区', 'altdq', '654300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('810000', '0', '1', '810000', '香港特别行政区', 'xgtbxzq', '810000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('810100', '810000', '2', '810100', '香港岛', 'xgd', '810100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('810200', '810000', '2', '810200', '九龙', 'jl', '810200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('810300', '810000', '2', '810300', '新界', 'xj', '810300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('820000', '0', '1', '820000', '澳门特别行政区', 'amtbxzq', '820000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('820100', '820000', '2', '820100', '澳门半岛', 'ambd', '820100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('820300', '820000', '2', '820300', '路环岛', 'lhd', '820300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('820400', '820000', '2', '820400', '凼仔岛', 'dzd', '820400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('830000', '0', '1', '830000', '台湾省', 'tws', '830000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('830100', '830000', '2', '830100', '台北市', 'tbs', '830100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('830200', '830000', '2', '830200', '高雄市', 'gxs', '830200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('830300', '830000', '2', '830300', '台南市', 'tns', '830300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('830400', '830000', '2', '830400', '台中市', 'tzs', '830400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('830500', '830000', '2', '830500', '南投县', 'ntx', '830500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('830600', '830000', '2', '830600', '基隆市', 'jls', '830600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('830700', '830000', '2', '830700', '新竹市', 'xzs', '830700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('830800', '830000', '2', '830800', '嘉义市', 'jys', '830800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('830900', '830000', '2', '830900', '宜兰县', 'ylx', '830900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('831000', '830000', '2', '831000', '新竹县', 'xzx', '831000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('831100', '830000', '2', '831100', '桃园县', 'tyx', '831100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('831200', '830000', '2', '831200', '苗栗县', 'mlx', '831200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('831300', '830000', '2', '831300', '彰化县', 'zhx', '831300', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('831400', '830000', '2', '831400', '嘉义县', 'jyx', '831400', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('831500', '830000', '2', '831500', '云林县', 'ylx', '831500', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('831600', '830000', '2', '831600', '屏东县', 'pdx', '831600', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('831700', '830000', '2', '831700', '台东县', 'tdx', '831700', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('831800', '830000', '2', '831800', '花莲县', 'hlx', '831800', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('831900', '830000', '2', '831900', '澎湖县', 'phx', '831900', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('832000', '830000', '2', '832000', '新北市', 'xbs', '832000', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('832100', '830000', '2', '832100', '台中县', 'tzx', '832100', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);
INSERT INTO `sys_area` VALUES ('832200', '830000', '2', '832200', '连江县', 'ljx', '832200', null, '1', null, '2016-07-20 00:00:00', null, null, null, null, null);

-- ----------------------------
-- Table structure for sys_dbbackup
-- ----------------------------
DROP TABLE IF EXISTS `sys_dbbackup`;
CREATE TABLE `sys_dbbackup` (
  `F_Id` varchar(50) NOT NULL COMMENT '备份主键',
  `F_BackupType` varchar(50) DEFAULT NULL COMMENT '备份类型',
  `F_DbName` varchar(50) DEFAULT NULL COMMENT '数据库名称',
  `F_FileName` varchar(50) DEFAULT NULL COMMENT '文件名称',
  `F_FileSize` varchar(50) DEFAULT NULL COMMENT '文件大小',
  `F_FilePath` text COMMENT '文件路径',
  `F_BackupTime` datetime DEFAULT NULL COMMENT '备份时间',
  `F_SortCode` int(11) DEFAULT NULL COMMENT '排序码',
  `F_DeleteMark` tinyint(4) DEFAULT NULL COMMENT '删除标志',
  `F_EnabledMark` tinyint(4) DEFAULT NULL COMMENT '有效标志',
  `F_Description` text COMMENT '描述',
  `F_CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `F_CreatorUserId` varchar(50) DEFAULT NULL COMMENT '创建用户',
  `F_LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `F_LastModifyUserId` varchar(50) DEFAULT NULL COMMENT '最后修改用户',
  `F_DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  `F_DeleteUserId` text COMMENT '删除用户',
  PRIMARY KEY (`F_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='数据库备份';

-- ----------------------------
-- Records of sys_dbbackup
-- ----------------------------

-- ----------------------------
-- Table structure for sys_filterip
-- ----------------------------
DROP TABLE IF EXISTS `sys_filterip`;
CREATE TABLE `sys_filterip` (
  `F_Id` varchar(50) NOT NULL COMMENT '过滤主键',
  `F_Type` tinyint(4) DEFAULT NULL COMMENT '类型',
  `F_StartIP` varchar(50) DEFAULT NULL COMMENT '开始IP',
  `F_EndIP` varchar(50) DEFAULT NULL COMMENT '结束IP',
  `F_SortCode` int(11) DEFAULT NULL COMMENT '排序码',
  `F_DeleteMark` tinyint(4) DEFAULT NULL COMMENT '删除标志',
  `F_EnabledMark` tinyint(4) DEFAULT NULL COMMENT '有效标志',
  `F_Description` text COMMENT '描述',
  `F_CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `F_CreatorUserId` varchar(50) DEFAULT NULL COMMENT '创建用户',
  `F_LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `F_LastModifyUserId` varchar(50) DEFAULT NULL COMMENT '最后修改用户',
  `F_DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  `F_DeleteUserId` text COMMENT '删除用户',
  PRIMARY KEY (`F_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='过滤IP';

-- ----------------------------
-- Records of sys_filterip
-- ----------------------------
INSERT INTO `sys_filterip` VALUES ('b3fbe66f-82cd-4f4a-ada3-61eb5a2d9eee', '1', '192.168.1.1', '192.168.1.10', '0', null, '1', '测试', '2016-07-18 17:52:47', null, '2018-10-30 18:57:46', null, null, null);

-- ----------------------------
-- Table structure for sys_items
-- ----------------------------
DROP TABLE IF EXISTS `sys_items`;
CREATE TABLE `sys_items` (
  `F_Id` varchar(50) NOT NULL COMMENT '主表主键',
  `F_ParentId` varchar(50) DEFAULT NULL COMMENT '父级',
  `F_EnCode` varchar(50) DEFAULT NULL COMMENT '编码',
  `F_FullName` varchar(50) DEFAULT NULL COMMENT '名称',
  `F_IsTree` tinyint(4) DEFAULT NULL COMMENT '树型',
  `F_Layers` int(11) DEFAULT NULL COMMENT '层次',
  `F_SortCode` int(11) DEFAULT NULL COMMENT '排序码',
  `F_DeleteMark` tinyint(4) DEFAULT NULL COMMENT '删除标志',
  `F_EnabledMark` tinyint(4) DEFAULT NULL COMMENT '有效标志',
  `F_Description` text COMMENT '描述',
  `F_CreatorTime` datetime DEFAULT NULL COMMENT '创建日期',
  `F_CreatorUserId` varchar(50) DEFAULT NULL COMMENT '创建用户主键',
  `F_LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `F_LastModifyUserId` varchar(50) DEFAULT NULL COMMENT '最后修改用户',
  `F_DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  `F_DeleteUserId` varchar(50) DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`F_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='选项主表';

-- ----------------------------
-- Records of sys_items
-- ----------------------------
INSERT INTO `sys_items` VALUES ('00F76465-DBBA-484A-B75C-E81DEE9313E6', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'Education', '学历', '0', '2', '8', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_items` VALUES ('0DF5B725-5FB8-487F-B0E4-BC563A77EB04', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'DbType', '数据库类型', '0', '2', '4', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_items` VALUES ('15023A4E-4856-44EB-BE71-36A106E2AA59', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', '103', '民族', '0', '2', '14', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_items` VALUES ('2748F35F-4EE2-417C-A907-3453146AAF67', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'Certificate', '证件名称', '0', '2', '7', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_items` VALUES ('77070117-3F1A-41BA-BF81-B8B85BF10D5E', '0', 'Sys_Items', '通用字典', '0', '1', '1', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_items` VALUES ('8CEB2F71-026C-4FA6-9A61-378127AE7320', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', '102', '生育', '0', '2', '13', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_items` VALUES ('954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'AuditState', '审核状态', '0', '2', '6', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_items` VALUES ('9a7079bd-0660-4549-9c2d-db5e8616619f', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'DbLogType', '系统日志', null, null, '16', null, '1', null, '2016-07-19 17:09:45', null, null, null, null, null);
INSERT INTO `sys_items` VALUES ('9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'OrganizeCategory', '机构分类', '0', '2', '2', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_items` VALUES ('BDD797C3-2323-4868-9A63-C8CC3437AEAA', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', '104', '性别', '0', '2', '15', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_items` VALUES ('D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', 'RoleType', '角色类型', '0', '2', '3', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_items` VALUES ('FA7537E2-1C64-4431-84BF-66158DD63269', '77070117-3F1A-41BA-BF81-B8B85BF10D5E', '101', '婚姻', '0', '2', '12', '0', '1', null, null, null, null, null, null, null);

-- ----------------------------
-- Table structure for sys_itemsdetail
-- ----------------------------
DROP TABLE IF EXISTS `sys_itemsdetail`;
CREATE TABLE `sys_itemsdetail` (
  `F_Id` varchar(50) NOT NULL COMMENT '明细主键',
  `F_ItemId` varchar(50) DEFAULT NULL COMMENT '主表主键',
  `F_ParentId` varchar(50) DEFAULT NULL COMMENT '父级',
  `F_ItemCode` varchar(50) DEFAULT NULL COMMENT '编码',
  `F_ItemName` varchar(50) DEFAULT NULL COMMENT '名称',
  `F_SimpleSpelling` text COMMENT '简拼',
  `F_IsDefault` tinyint(4) DEFAULT NULL COMMENT '默认',
  `F_Layers` int(11) DEFAULT NULL COMMENT '层次',
  `F_SortCode` int(11) DEFAULT NULL COMMENT '排序码',
  `F_DeleteMark` tinyint(4) DEFAULT NULL COMMENT '删除标志',
  `F_EnabledMark` tinyint(4) DEFAULT NULL COMMENT '有效标志',
  `F_Description` text COMMENT '描述',
  `F_CreatorTime` datetime DEFAULT NULL COMMENT '创建日期',
  `F_CreatorUserId` varchar(50) DEFAULT NULL COMMENT '创建用户主键',
  `F_LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `F_LastModifyUserId` varchar(50) DEFAULT NULL COMMENT '最后修改用户',
  `F_DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  `F_DeleteUserId` varchar(50) DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`F_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='选项明细表';

-- ----------------------------
-- Records of sys_itemsdetail
-- ----------------------------
INSERT INTO `sys_itemsdetail` VALUES ('0096ad81-4317-486e-9144-a6a02999ff19', '2748F35F-4EE2-417C-A907-3453146AAF67', null, '4', '护照', null, '0', null, '4', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('04aba88d-f09b-46c6-bd90-a38471399b0e', 'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', null, '2', '业务角色', null, '0', null, '2', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('19EE595A-E775-409D-A48F-B33CF9F262C7', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', null, 'WorkGroup', '小组', null, '0', null, '7', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('1b296511-f689-466b-9200-e276d6a9652d', '00F76465-DBBA-484A-B75C-E81DEE9313E6', null, '1', '小学', null, '0', '0', '1', null, '1', null, '2018-11-03 17:50:41', null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('24e39617-f04e-4f6f-9209-ad71e870e7c6', '9a7079bd-0660-4549-9c2d-db5e8616619f', null, 'Submit', '提交', null, '0', null, '7', null, '1', null, '2016-07-19 17:11:19', null, '2016-07-19 18:20:54', null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('27e85cb8-04e7-447b-911d-dd1e97dfab83', '0DF5B725-5FB8-487F-B0E4-BC563A77EB04', null, 'Oracle', 'Oracle', null, '0', null, '2', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('2B540AC5-6E64-4688-BB60-E0C01DFA982C', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', null, 'SubCompany', '子公司', null, null, null, '4', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('2C3715AC-16F7-48FC-AB40-B0931DB1E729', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', null, 'Area', '区域', null, null, null, '2', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('34222d46-e0c6-446e-8150-dbefc47a1d5f', '00F76465-DBBA-484A-B75C-E81DEE9313E6', null, '6', '本科', null, '0', null, '6', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('34a642b2-44d4-485f-b3fc-6cce24f68b0f', '0DF5B725-5FB8-487F-B0E4-BC563A77EB04', null, 'MySql', 'MySql', null, '0', null, '3', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('355ad7a4-c4f8-4bd3-9c72-ff07983da0f0', '00F76465-DBBA-484A-B75C-E81DEE9313E6', null, '9', '其他', null, '0', null, '9', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('392f88a8-02c2-49eb-8aed-b2acf474272a', '9a7079bd-0660-4549-9c2d-db5e8616619f', null, 'Update', '修改', null, '0', null, '6', null, '1', null, '2016-07-19 17:11:14', null, '2016-07-19 18:20:49', null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('3c884a03-4f34-4150-b134-966387f1de2a', '9a7079bd-0660-4549-9c2d-db5e8616619f', null, 'Exit', '退出', null, '0', null, '2', null, '1', null, '2016-07-19 17:10:49', null, '2016-07-19 18:20:23', null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('3f280e2b-92f6-466c-8cc3-d7c8ff48cc8d', '00F76465-DBBA-484A-B75C-E81DEE9313E6', null, '7', '硕士', null, '0', null, '7', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('41053517-215d-4e11-81cd-367c0e9578d7', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', null, '3', '通过', null, '0', null, '3', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('433511a9-78bd-41a0-ab25-e4d4b3423055', '00F76465-DBBA-484A-B75C-E81DEE9313E6', null, '2', '初中', null, '0', null, '2', '0', '1', '&nbsp;', null, null, '2018-11-03 17:50:18', null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('486a82e3-1950-425e-b2ce-b5d98f33016a', '00F76465-DBBA-484A-B75C-E81DEE9313E6', null, '5', '大专', null, '0', null, '5', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('48c4e0f5-f570-4601-8946-6078762db3bf', '2748F35F-4EE2-417C-A907-3453146AAF67', null, '3', '军官证', null, '0', null, '3', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('49300258-1227-4b85-b6a2-e948dbbe57a4', '15023A4E-4856-44EB-BE71-36A106E2AA59', null, '汉族', '汉族', null, '0', null, '1', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('49b68663-ad01-4c43-b084-f98e3e23fee8', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', null, '7', '废弃', null, '0', null, '7', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('4c2f2428-2e00-4336-b9ce-5a61f24193f6', '2748F35F-4EE2-417C-A907-3453146AAF67', null, '2', '士兵证', null, '0', null, '2', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('582e0b66-2ee9-4885-9f0c-3ce3ebf96e12', '8CEB2F71-026C-4FA6-9A61-378127AE7320', null, '1', '已育', null, '0', null, '1', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('5d6def0e-e2a7-48eb-b43c-cc3631f60dd7', 'BDD797C3-2323-4868-9A63-C8CC3437AEAA', null, '1', '男', null, '0', null, '1', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('63acf96d-6115-4d76-a994-438f59419aad', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', null, '5', '退回', null, '0', null, '5', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('643209c8-931b-4641-9e04-b8bdd11800af', '9a7079bd-0660-4549-9c2d-db5e8616619f', null, 'Login', '登录', null, '0', null, '1', null, '1', null, '2016-07-19 17:10:39', null, '2016-07-19 18:20:17', null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('738edf2a-d59f-4992-97ef-d847db23bcb8', 'FA7537E2-1C64-4431-84BF-66158DD63269', null, '1', '已婚', null, '0', null, '1', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('795f2695-497a-4f5e-ab1d-706095c1edb9', '9a7079bd-0660-4549-9c2d-db5e8616619f', null, 'Other', '其他', null, '0', null, '0', null, '1', null, '2016-07-19 17:10:33', null, '2016-07-19 18:20:09', null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('7a6d1bc4-3ec7-4c57-be9b-b4c97d60d5f6', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', null, '1', '草稿', null, '0', null, '1', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('7c1135be-0148-43eb-ae49-62a1e16ebbe3', 'FA7537E2-1C64-4431-84BF-66158DD63269', null, '5', '其他', null, '0', null, '5', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('7fc8fa11-4acf-409a-a771-aaf1eb81e814', '9a7079bd-0660-4549-9c2d-db5e8616619f', null, 'Exception', '异常', null, '0', null, '8', null, '1', null, '2016-07-19 17:11:25', null, '2016-07-19 18:21:01', null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('822baf7c-abdb-4257-9b78-1f550806f544', 'BDD797C3-2323-4868-9A63-C8CC3437AEAA', null, '0', '女', null, '0', null, '2', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('8b7b38bf-07c5-4f71-a853-41c5add4a94e', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', null, '6', '完成', null, '0', null, '6', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('930b8de2-049f-4753-b9fd-87f484911ee4', '00F76465-DBBA-484A-B75C-E81DEE9313E6', null, '8', '博士', null, '0', null, '8', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('9b6a2225-6138-4cf2-9845-1bbecdf9b3ed', '8CEB2F71-026C-4FA6-9A61-378127AE7320', null, '3', '其他', null, '0', null, '3', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('a13ccf0d-ac8f-44ac-a522-4a54edf1f0fa', '9a7079bd-0660-4549-9c2d-db5e8616619f', null, 'Delete', '删除', null, '0', null, '5', null, '1', null, '2016-07-19 17:11:09', null, '2016-07-19 18:20:43', null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('a4974810-d88d-4d54-82cc-fd779875478f', '00F76465-DBBA-484A-B75C-E81DEE9313E6', null, '4', '中专', null, '0', null, '4', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('A64EBB80-6A24-48AF-A10E-B6A532C32CA6', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', null, 'Department', '部门', null, null, null, '5', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('a6f271f9-8653-4c5c-86cf-4cd00324b3c3', 'FA7537E2-1C64-4431-84BF-66158DD63269', null, '4', '丧偶', null, '0', null, '4', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('a7c4aba2-a891-4558-9b0a-bd7a1100a645', 'FA7537E2-1C64-4431-84BF-66158DD63269', null, '2', '未婚', null, '0', null, '2', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('acb128a6-ff63-4e25-b1e8-0a336ed3ab18', '00F76465-DBBA-484A-B75C-E81DEE9313E6', null, '3', '高中', null, '0', null, '3', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('ace2d5e8-56d4-4c8b-8409-34bc272df404', '2748F35F-4EE2-417C-A907-3453146AAF67', null, '5', '其它', null, '0', null, '5', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('B97BD7F5-B212-40C1-A1F7-DD9A2E63EEF2', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', null, 'Group', '集团', null, null, null, '1', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('cc6daa5c-a71c-4b2c-9a98-336bc3ee13c8', 'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', null, '3', '其他角色', null, '0', null, '3', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('ccc8e274-75da-4eb8-bed0-69008ab7c41c', '9a7079bd-0660-4549-9c2d-db5e8616619f', null, 'Visit', '访问', null, '0', null, '3', null, '1', null, '2016-07-19 17:10:55', null, '2016-07-19 18:20:29', null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('ce340c73-5048-4940-b86e-e3b3d53fdb2c', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', null, '2', '提交', null, '0', null, '2', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('D082BDB9-5C34-49BF-BD51-4E85D7BFF646', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', null, 'Company', '公司', null, null, null, '3', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('D1F439B9-D80E-4547-9EF0-163391854AB5', '9EB4602B-BF9A-4710-9D80-C73CE89BEC5D', null, 'SubDepartment', '子部门', null, null, null, '6', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('d69cb819-2bb3-4e1d-9917-33b9a439233d', '2748F35F-4EE2-417C-A907-3453146AAF67', null, '1', '身份证', null, '0', null, '1', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('de2167f3-40fe-4bf7-b8cb-5b1c554bad7a', '8CEB2F71-026C-4FA6-9A61-378127AE7320', null, '2', '未育', null, '0', null, '2', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('e1979a4f-7fc1-42b9-a0e2-52d7059e8fb9', '954AB9A1-9928-4C6D-820A-FC1CDC85CDE0', null, '4', '待审', null, '0', null, '4', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('e5079bae-a8c0-4209-9019-6a2b4a3a7dac', 'D94E4DC1-C2FD-4D19-9D5D-3886D39900CE', null, '1', '系统角色', null, '0', null, '1', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('e545061c-93fd-4ca2-ab29-b43db9db798b', '9a7079bd-0660-4549-9c2d-db5e8616619f', null, 'Create', '新增', null, '0', null, '4', null, '1', null, '2016-07-19 17:11:03', null, '2016-07-19 18:20:35', null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('f9609400-7caf-49af-ae3c-7671a9292fb3', 'FA7537E2-1C64-4431-84BF-66158DD63269', null, '3', '离异', null, '0', null, '3', '0', '1', null, null, null, null, null, null, null);
INSERT INTO `sys_itemsdetail` VALUES ('fa6c1873-888c-4b70-a2cc-59fccbb22078', '0DF5B725-5FB8-487F-B0E4-BC563A77EB04', null, 'SqlServer', 'SqlServer', null, '0', null, '1', '0', '1', null, null, null, null, null, null, null);

-- ----------------------------
-- Table structure for sys_log
-- ----------------------------
DROP TABLE IF EXISTS `sys_log`;
CREATE TABLE `sys_log` (
  `F_Id` varchar(50) NOT NULL COMMENT '日志主键',
  `F_Date` datetime DEFAULT NULL COMMENT '日期',
  `F_Account` varchar(50) DEFAULT NULL COMMENT '用户名',
  `F_NickName` varchar(50) DEFAULT NULL COMMENT '姓名',
  `F_Type` varchar(50) DEFAULT NULL COMMENT '类型',
  `F_IPAddress` varchar(50) DEFAULT NULL COMMENT 'IP地址',
  `F_IPAddressName` varchar(50) DEFAULT NULL COMMENT 'IP所在城市',
  `F_ModuleId` varchar(50) DEFAULT NULL COMMENT '系统模块Id',
  `F_ModuleName` varchar(50) DEFAULT NULL COMMENT '系统模块',
  `F_Result` tinyint(4) DEFAULT NULL COMMENT '结果',
  `F_Description` text COMMENT '描述',
  `F_CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `F_CreatorUserId` varchar(50) DEFAULT NULL COMMENT '创建用户',
  PRIMARY KEY (`F_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='系统日志';

-- ----------------------------
-- Records of sys_log
-- ----------------------------
INSERT INTO `sys_log` VALUES ('03729826-2757-43bf-8f7e-17ddb7394b14', '2018-11-13 11:40:30', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 11:40:30', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('03cf9192-b26d-43f6-ab29-c79d4af3628e', '2018-11-12 19:03:33', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-12 19:03:33', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('05f18e4b-0b38-407b-b1e4-a773ed553640', '2018-11-12 10:48:39', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-12 10:48:39', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('0782b0e8-3aed-4cff-bf67-dfd3418a0096', '2018-11-14 15:00:13', 'admin', '超级管理员', 'Login', '154.48.247.21', '香港特别行政区', null, '系统登录', '1', '登录成功', '2018-11-14 15:00:13', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('0f577b20-0408-41fd-97da-d58718c11162', '2018-11-12 17:22:19', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-12 17:22:19', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('1289b2f8-28ee-4ff3-8e00-516b5a6228d9', '2018-11-14 11:34:31', 'admin', '超级管理员', 'Login', '154.48.247.21', '香港特别行政区', null, '系统登录', '1', '登录成功', '2018-11-14 11:34:32', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('143636f7-5b8d-4168-b97b-fd84823b39e7', '2018-11-14 15:01:44', 'admin', '超级管理员', 'Login', '10.122.119.27', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-14 15:01:44', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('19b94edc-8877-4ca6-94a4-2acd1a0f9017', '2018-11-14 11:57:25', 'admin', '超级管理员', 'Login', '154.48.247.21', '香港特别行政区', null, '系统登录', '1', '登录成功', '2018-11-14 11:57:26', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('26238315-3aa2-4aaf-a397-73cb962e5220', '2018-11-12 17:21:19', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-12 17:21:19', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('2a80f12f-2a75-4746-a64d-4ae06232a9b7', '2018-11-12 10:51:18', 'admin', '超级管理员', 'Exit', '192.168.1.123', '本地局域网', null, '系统登录', '1', '安全退出系统', '2018-11-12 10:51:18', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('2be950c4-89ab-414c-8870-ae21a097628f', '2018-11-13 23:08:00', 'admin', '超级管理员', 'Login', '10.122.119.27', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 23:08:00', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('3327cdce-5c7c-4b1d-9f9e-a460b51f93c5', '2018-11-12 10:50:36', 'admin', '超级管理员', 'Exit', '192.168.1.123', '本地局域网', null, '系统登录', '1', '安全退出系统', '2018-11-12 10:50:37', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('3577fb96-4523-43e1-9a21-d4cdfedabd7e', '2018-11-12 17:58:18', 'admin', '超级管理员', 'Exit', '192.168.1.123', '本地局域网', null, '系统登录', '1', '安全退出系统', '2018-11-12 17:58:19', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('376e25b9-b769-4f9e-b452-562b9222dc19', '2018-11-21 08:48:57', 'admin', '超级管理员', 'Login', '220.202.152.81', '湖南省长沙市 联通', null, '系统登录', '1', '登录成功', '2018-11-21 08:48:57', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('3e9e4fa9-3611-4a5a-b4a4-5d77260f40b8', '2018-11-15 23:23:53', 'admin', '超级管理员', 'Login', '110.54.160.216', '菲律宾', null, '系统登录', '1', '登录成功', '2018-11-15 23:23:54', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('424d7d22-9d91-45f2-b5a4-892dea900998', '2018-11-13 10:14:19', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 10:14:19', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('42a5cad7-f971-42ed-924c-93e403544a0b', '2018-11-13 15:14:56', 'admin', '超级管理员', 'Exit', '192.168.1.123', '本地局域网', null, '系统登录', '1', '安全退出系统', '2018-11-13 15:14:57', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('442738bc-2887-4edc-a7f4-06d35541bbaa', '2018-11-12 10:51:25', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-12 10:51:25', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('46629243-fde9-4157-be01-c043da520728', '2018-11-13 19:01:25', 'admin', 'admin', 'Login', '43.250.200.24', '湖南省长沙市 联通', null, '系统登录', '0', '登录失败，验证码错误，请重新输入', '2018-11-13 19:01:28', null);
INSERT INTO `sys_log` VALUES ('47c3985b-19b3-49d4-adc9-987c8717b2a0', '2018-11-12 19:03:24', 'admin', '超级管理员', 'Exit', '192.168.1.123', '本地局域网', null, '系统登录', '1', '安全退出系统', '2018-11-12 19:03:25', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('4d940dd2-6aee-4d7f-bb22-a36b705f2fe7', '2018-11-14 19:45:11', 'admin', '超级管理员', 'Login', '183.17.232.89', '广东省深圳市 电信', null, '系统登录', '1', '登录成功', '2018-11-14 19:45:11', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('4db7f874-aebb-42a8-83c4-04a18b331a95', '2018-11-13 18:29:44', 'admin', '超级管理员', 'Login', '127.0.0.1', '保留地址', null, '系统登录', '1', '登录成功', '2018-11-13 18:29:44', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('4ef6f46f-b164-4ec4-af30-82a7dd0e773b', '2018-11-14 22:08:15', 'admin', '超级管理员', 'Login', '183.17.233.9', '广东省深圳市 电信', null, '系统登录', '1', '登录成功', '2018-11-14 22:08:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('5040be37-dc94-4eb2-ad14-dbbf3ed3b2f4', '2018-11-15 21:34:48', 'admin', '超级管理员', 'Login', '183.17.232.173', '广东省深圳市 电信', null, '系统登录', '1', '登录成功', '2018-11-15 21:34:48', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('54f95628-2721-441a-840b-079c611da692', '2018-11-12 10:59:03', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-12 10:59:03', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('62cf19c7-3c04-499d-bb36-d006491406a1', '2018-11-13 15:15:04', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 15:15:04', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('686132be-07de-4570-a835-dd98f7fd4de3', '2018-11-15 21:09:52', 'admin', '超级管理员', 'Login', '110.54.160.216', '菲律宾', null, '系统登录', '1', '登录成功', '2018-11-15 21:09:52', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('6a319afc-bac9-4c8b-a877-5553f074810b', '2018-11-13 21:22:25', 'admin', '超级管理员', 'Login', '130.105.167.88', '菲律宾', null, '系统登录', '1', '登录成功', '2018-11-13 21:22:26', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('6b0a4e7e-9398-4e03-829f-a5edc0ba0eec', '2018-11-12 17:24:43', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-12 17:24:43', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('74004da4-d710-467b-a356-7da151224a50', '2018-11-20 19:32:45', 'admin', '超级管理员', 'Login', '110.54.195.233', '菲律宾', null, '系统登录', '1', '登录成功', '2018-11-20 19:32:45', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('7414e027-2339-4a6f-8545-90476f57b4cf', '2018-11-13 15:19:18', 'admin', '超级管理员', 'Exit', '192.168.1.123', '本地局域网', null, '系统登录', '1', '安全退出系统', '2018-11-13 15:19:19', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('7551327f-79e5-4630-9da0-c243ff0d30db', '2018-11-21 11:30:02', 'admin', '超级管理员', 'Login', '154.48.247.21', '美国', null, '系统登录', '1', '登录成功', '2018-11-21 11:30:02', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('79caf4b9-ea2a-4ff3-bef9-a3f0f261fd1e', '2018-11-13 22:19:57', 'admin', '超级管理员', 'Login', '10.122.119.27', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 22:19:57', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('7ae6a5ff-d247-4078-a9fc-a99f69869d1a', '2018-11-12 17:22:11', 'admin', 'admin', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '0', '登录失败，验证码错误，请重新输入', '2018-11-12 17:22:11', null);
INSERT INTO `sys_log` VALUES ('7ddcf07d-4d81-4b3e-b212-3a7611ccd9ab', '2018-11-13 16:49:14', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 16:49:14', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('812d368f-151e-43b6-a09e-8648bb7c870e', '2018-11-12 10:50:47', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-12 10:50:47', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('86165d5e-7968-42d3-8371-df132a61f879', '2018-11-15 22:32:14', 'admin', '超级管理员', 'Login', '183.17.237.15', '广东省深圳市 电信', null, '系统登录', '1', '登录成功', '2018-11-15 22:32:14', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('8a6d4bc2-00c0-4c93-a7ff-1e2e76e238ce', '2018-11-12 10:46:54', 'admin', 'admin', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '0', '登录失败，密码不正确，请重新输入', '2018-11-12 10:46:58', null);
INSERT INTO `sys_log` VALUES ('8b71e2ba-4b77-4cc3-a2b3-ce02d2212d56', '2018-11-12 17:22:02', 'admin', '超级管理员', 'Exit', '192.168.1.123', '本地局域网', null, '系统登录', '1', '安全退出系统', '2018-11-12 17:22:02', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('90602f09-fdf1-4eeb-907f-122b81e6e653', '2018-11-13 22:23:59', 'admin', '超级管理员', 'Login', '183.17.239.19', '广东省深圳市 电信', null, '系统登录', '1', '登录成功', '2018-11-13 22:24:00', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('942454d2-e885-4b84-9261-2f13a988514f', '2018-11-13 16:31:59', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 16:32:00', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('9446bde8-1a1d-4d86-9cf5-f0c10c05dfa6', '2018-11-13 16:54:52', 'admin', '超级管理员', 'Exit', '192.168.1.123', '本地局域网', null, '系统登录', '1', '安全退出系统', '2018-11-13 16:54:53', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('97a3f6e9-5837-4f80-b3e8-a746be685fd2', '2018-11-15 14:30:19', 'admin', '超级管理员', 'Login', '154.48.247.21', '香港特别行政区', null, '系统登录', '1', '登录成功', '2018-11-15 14:30:20', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('98788c0f-8d7b-497f-823d-586ffdf78b69', '2018-11-13 16:50:25', 'admin', 'admin', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '0', '登录失败，密码不正确，请重新输入', '2018-11-13 16:50:25', null);
INSERT INTO `sys_log` VALUES ('98c67c63-9c09-4433-80a7-b982da24fc30', '2018-11-13 11:10:03', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 11:10:03', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('998aabe9-16ff-43ac-ac90-5e55d8249e44', '2018-11-12 11:02:02', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-12 11:02:02', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('99ec72d2-9df7-47e8-87ad-26cc05cae065', '2018-11-13 16:55:11', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 16:55:11', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('9af792ce-94e5-4d5b-8837-2175bf589133', '2018-11-12 19:02:18', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-12 19:02:18', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('a004b818-6af1-49ee-b57e-094418cd6a83', '2018-11-14 11:34:16', 'admin', 'admin', 'Login', '154.48.247.21', '美国', null, '系统登录', '0', '登录失败，验证码错误，请重新输入', '2018-11-14 11:34:22', null);
INSERT INTO `sys_log` VALUES ('a38d16bd-cd01-42da-b738-6ba299cea665', '2018-11-13 13:04:14', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 13:04:15', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('aab9045f-e7c1-43f2-bfeb-e1a2912d6ba7', '2018-11-13 21:23:12', 'admin', '超级管理员', 'Login', '183.17.239.19', '广东省深圳市 电信', null, '系统登录', '1', '登录成功', '2018-11-13 21:23:13', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('adc71829-9814-40c4-9f4b-1ef78265eb81', '2018-11-13 16:50:33', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 16:50:33', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('b1d25511-1559-467e-89bf-ebb19c0072ad', '2018-11-14 18:08:40', 'admin', '超级管理员', 'Login', '154.48.247.21', '香港特别行政区', null, '系统登录', '1', '登录成功', '2018-11-14 18:08:40', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('b2493553-ba15-4fba-a755-ffe6f0f373f0', '2018-11-21 08:50:24', 'admin', '超级管理员', 'Login', '220.202.152.81', '湖南省长沙市 联通', null, '系统登录', '1', '登录成功', '2018-11-21 08:50:24', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('bff42d19-c662-4e16-96a7-eb8b41bea2af', '2018-11-12 11:04:08', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-12 11:04:08', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('c2822db0-96bb-4ab8-b869-5b94ec2a9c2f', '2018-11-13 10:55:53', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 10:55:53', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('c6a406d0-2f44-4790-bdfc-9c4102da38b9', '2018-11-13 15:02:40', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 15:02:40', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('c6f07508-e1bd-4170-8fc7-0b43729459ea', '2018-11-13 22:19:56', 'admin', 'admin', 'Login', '10.122.119.27', '本地局域网', null, '系统登录', '0', '登录失败，验证码错误，请重新输入', '2018-11-13 22:19:56', null);
INSERT INTO `sys_log` VALUES ('c92011c4-0417-4f8c-bbba-5300829f3dc6', '2018-11-13 17:24:57', 'admin', '超级管理员', 'Login', '154.48.247.21', '香港特别行政区', null, '系统登录', '1', '登录成功', '2018-11-13 17:24:57', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('cabf0a5e-7379-4587-9ea2-30c8aebbe155', '2018-11-13 15:19:34', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 15:19:34', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('cdac6879-da71-4b4f-b2a4-523e4a4181df', '2018-11-13 16:50:08', 'admin', '超级管理员', 'Exit', '192.168.1.123', '本地局域网', null, '系统登录', '1', '安全退出系统', '2018-11-13 16:50:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('d3160a73-f009-4d2a-8ffb-15683fb26e7b', '2018-11-12 17:58:31', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-12 17:58:31', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('d43ffb31-d05e-417b-9cde-767069148a1a', '2018-11-13 14:08:31', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 14:08:31', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('d8fd52ed-29b9-48a6-9c64-9f0fd04cf2e3', '2018-11-14 20:37:45', 'admin', '超级管理员', 'Login', '110.54.190.28', '菲律宾', null, '系统登录', '1', '登录成功', '2018-11-14 20:37:45', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('d9bdefbc-fa18-4e4f-9cd2-e13b44f8dc3b', '2018-11-13 14:19:42', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 14:19:43', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('dc6a0791-0a83-44e9-a2a1-b67750536f8f', '2018-11-13 10:23:38', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 10:23:38', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('e8e9dbd1-44b1-4b32-b735-3f948465f5bb', '2018-11-12 11:01:54', 'admin', '超级管理员', 'Exit', '192.168.1.123', '本地局域网', null, '系统登录', '1', '安全退出系统', '2018-11-12 11:01:55', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('ea230450-749e-4962-9eb9-6a28339d48f3', '2018-11-13 19:01:35', 'admin', '超级管理员', 'Login', '43.250.200.24', '湖南省长沙市 联通', null, '系统登录', '1', '登录成功', '2018-11-13 19:01:36', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('f28a41b9-5dd3-4b62-97fb-a69253db6f59', '2018-11-12 10:44:44', 'admin', 'admin', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '0', '登录失败，密码不正确，请重新输入', '2018-11-12 10:44:48', null);
INSERT INTO `sys_log` VALUES ('f5a0a2ec-d7f6-47ca-a1c3-0be299b805cb', '2018-11-13 17:37:11', 'admin', '超级管理员', 'Login', '192.168.1.123', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-13 17:37:11', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('f927e513-024a-4df5-892f-0017264fce46', '2018-11-14 11:55:13', 'admin', '超级管理员', 'Exit', '154.48.247.21', '香港特别行政区', null, '系统登录', '1', '安全退出系统', '2018-11-14 11:55:14', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');
INSERT INTO `sys_log` VALUES ('fad587fd-b9ae-4d05-9927-7e8d98f5d4a5', '2018-11-16 16:32:20', 'admin', '超级管理员', 'Login', '172.16.0.2', '本地局域网', null, '系统登录', '1', '登录成功', '2018-11-16 16:32:20', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba');

-- ----------------------------
-- Table structure for sys_module
-- ----------------------------
DROP TABLE IF EXISTS `sys_module`;
CREATE TABLE `sys_module` (
  `F_Id` varchar(50) NOT NULL COMMENT '模块主键',
  `F_ParentId` varchar(50) DEFAULT NULL COMMENT '父级',
  `F_Layers` int(11) DEFAULT NULL COMMENT '层次',
  `F_EnCode` varchar(50) DEFAULT NULL COMMENT '编码',
  `F_FullName` varchar(50) DEFAULT NULL COMMENT '名称',
  `F_Icon` varchar(50) DEFAULT NULL COMMENT '图标',
  `F_UrlAddress` text COMMENT '连接',
  `F_Target` varchar(50) DEFAULT NULL COMMENT '目标',
  `F_IsMenu` tinyint(4) DEFAULT NULL COMMENT '菜单',
  `F_IsExpand` tinyint(4) DEFAULT NULL COMMENT '展开',
  `F_IsPublic` tinyint(4) DEFAULT NULL COMMENT '公共',
  `F_AllowEdit` tinyint(4) DEFAULT NULL COMMENT '允许编辑',
  `F_AllowDelete` tinyint(4) DEFAULT NULL COMMENT '允许删除',
  `F_SortCode` int(11) DEFAULT NULL COMMENT '排序码',
  `F_DeleteMark` tinyint(4) DEFAULT NULL COMMENT '删除标志',
  `F_EnabledMark` tinyint(4) DEFAULT NULL COMMENT '有效标志',
  `F_Description` text COMMENT '描述',
  `F_CreatorTime` datetime DEFAULT NULL COMMENT '创建日期',
  `F_CreatorUserId` varchar(50) DEFAULT NULL COMMENT '创建用户主键',
  `F_LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `F_LastModifyUserId` varchar(50) DEFAULT NULL COMMENT '最后修改用户',
  `F_DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  `F_DeleteUserId` varchar(50) DEFAULT NULL COMMENT '删除用户',
  `F_Show` tinyint(4) DEFAULT '1' COMMENT '是否显示在左侧菜单栏。1:是，0:否',
  PRIMARY KEY (`F_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='系统模块';

-- ----------------------------
-- Records of sys_module
-- ----------------------------
INSERT INTO `sys_module` VALUES ('252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '462027E0-0848-41DD-BCC3-025DCAE65555', '0', null, '机构管理', '&nbsp;', '/SystemManage/Organize/Index', 'iframe', '1', '0', '0', '0', '0', '50', '0', '1', '&nbsp;', null, null, '2018-11-12 11:00:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, '1');
INSERT INTO `sys_module` VALUES ('337A4661-99A5-4E5E-B028-861CACAF9917', '462027E0-0848-41DD-BCC3-025DCAE65555', '0', null, '区域管理', '&nbsp;', '/SystemManage/Area/Index', 'iframe', '1', '0', '0', '0', '0', '60', '0', '1', '&nbsp;', null, null, '2018-11-12 11:00:24', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, '1');
INSERT INTO `sys_module` VALUES ('38CA5A66-C993-4410-AF95-50489B22939C', '462027E0-0848-41DD-BCC3-025DCAE65555', '0', null, '用户管理', '&nbsp;', '/SystemManage/User/Index', 'iframe', '1', '0', '0', '0', '0', '10', '0', '1', '&nbsp;', null, null, '2018-11-12 11:00:35', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, '1');
INSERT INTO `sys_module` VALUES ('39E97B05-7B6F-4069-9972-6F9643BC3042', '9F56840F-DF92-4936-A48C-8F65A39291A2', '0', null, '注单列表', '&nbsp;', '/Tesla/BetOrder/Index', 'iframe', '1', '0', '0', '0', '0', '10', '0', '1', '&nbsp;', null, null, '2018-11-12 17:58:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, '1');
INSERT INTO `sys_module` VALUES ('3A95BBC6-CB5B-4438-869F-5F7B738E2568', null, null, null, '散点图', null, null, 'iframe', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '1');
INSERT INTO `sys_module` VALUES ('423A200B-FA5F-4B29-B7B7-A3F5474B725F', '462027E0-0848-41DD-BCC3-025DCAE65555', '0', null, '数据字典', '&nbsp;', '/SystemManage/ItemsData/Index', 'iframe', '1', '0', '0', '0', '0', '70', '0', '1', '&nbsp;', null, null, '2018-11-12 11:00:45', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, '1');
INSERT INTO `sys_module` VALUES ('42fe6bcd-7e39-4606-a1c3-87e795188bc3', '9F56840F-DF92-4936-A48C-8F65A39291A2', '0', null, '服务日志', '&nbsp;', '/Tesla/AppLog/Index', 'iframe', '0', '0', '0', '0', '0', '70', null, '1', '&nbsp;', '2018-11-08 15:08:46', '783ce87b-e18e-4e93-bb6c-51b5d0c3c6c6', '2018-11-12 19:03:22', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, '1');
INSERT INTO `sys_module` VALUES ('462027E0-0848-41DD-BCC3-025DCAE65555', '0', '0', null, '系统管理', 'fa fa-gears', '&nbsp;', 'expand', '0', '1', '0', '0', '0', '40', '0', '1', '&nbsp;', null, null, '2018-11-01 17:28:36', null, null, null, '1');
INSERT INTO `sys_module` VALUES ('51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '0', '0', null, '配置管理', 'fa fa-bar-chart-o', '&nbsp;', 'expand', '0', '1', '0', '0', '0', '20', '0', '1', '&nbsp;', null, null, '2018-11-01 17:28:20', null, null, null, '1');
INSERT INTO `sys_module` VALUES ('5328e771-aab3-4967-bfb9-a7f16f0d2020', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '0', null, '任务配置', '&nbsp;', '/Tesla/Task/Index', 'iframe', '0', '0', '0', '0', '0', '10', null, '1', '&nbsp;', '2018-11-01 15:55:41', null, '2018-11-12 17:21:59', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, '1');
INSERT INTO `sys_module` VALUES ('53df9c6b-c1e0-48c4-839b-641ce17cb217', '9F56840F-DF92-4936-A48C-8F65A39291A2', '0', null, '提现记录', '&nbsp;', '/Tesla/Withdraw/Index', 'iframe', '0', '0', '0', '0', '0', '40', null, '1', '&nbsp;', '2018-11-13 15:11:48', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2018-11-13 15:14:48', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, '1');
INSERT INTO `sys_module` VALUES ('5d1bfd33-1ab7-47d1-9d29-87820485960e', '9F56840F-DF92-4936-A48C-8F65A39291A2', '0', null, '客户端参数', '&nbsp;', '/Tesla/BetParam/Index', 'iframe', '0', '0', '0', '0', '0', '50', null, '1', '&nbsp;', '2018-11-14 11:53:38', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2018-11-14 11:53:54', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, '1');
INSERT INTO `sys_module` VALUES ('64A1C550-2C61-4A8C-833D-ACD0C012260F', '462027E0-0848-41DD-BCC3-025DCAE65555', '0', null, '系统菜单', '&nbsp;', '/SystemManage/Module/Index', 'iframe', '1', '0', '0', '0', '0', '30', '0', '1', '&nbsp;', null, null, '2018-11-01 15:58:42', null, null, null, '1');
INSERT INTO `sys_module` VALUES ('73FD1267-79BA-4E23-A152-744AF73117E9', '0', '0', null, '系统安全', 'fa fa-desktop', '&nbsp;', 'expand', '0', '1', '0', '0', '0', '30', '0', '1', '&nbsp;', null, null, '2018-11-01 17:28:25', null, null, null, '1');
INSERT INTO `sys_module` VALUES ('91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '462027E0-0848-41DD-BCC3-025DCAE65555', '0', null, '角色管理', '&nbsp;', '/SystemManage/Role/Index', 'iframe', '1', '0', '0', '0', '0', '20', '0', '1', '&nbsp;', null, null, '2018-11-12 11:00:59', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, '1');
INSERT INTO `sys_module` VALUES ('96EE855E-8CD2-47FC-A51D-127C131C9FB9', '73FD1267-79BA-4E23-A152-744AF73117E9', '0', null, '系统日志', '&nbsp;', '/SystemSecurity/Log/Index', 'iframe', '1', '0', '0', '0', '0', '3', '0', '1', '&nbsp;', null, null, '2018-11-12 11:01:32', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, '1');
INSERT INTO `sys_module` VALUES ('9f05e7af-120a-45a4-b8df-548ad04508fc', '9F56840F-DF92-4936-A48C-8F65A39291A2', '0', null, '充值记录', '&nbsp;', '/Tesla/Charge/Index', 'iframe', '0', '0', '0', '0', '0', '30', null, '1', '&nbsp;', '2018-11-13 15:09:36', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2018-11-13 15:14:39', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, '1');
INSERT INTO `sys_module` VALUES ('9F56840F-DF92-4936-A48C-8F65A39291A2', '0', '0', null, '统计报表', 'fa fa-tags', '&nbsp;', 'expand', '0', '1', '0', '0', '0', '10', '0', '1', '&nbsp;', null, null, '2018-11-01 17:28:30', null, null, null, '1');
INSERT INTO `sys_module` VALUES ('a3a4742d-ca39-42ec-b95a-8552a6fae579', '73FD1267-79BA-4E23-A152-744AF73117E9', '0', null, '访问控制', '&nbsp;', '/SystemSecurity/FilterIP/Index', 'iframe', '1', '0', '0', '0', '0', '2', null, '1', '&nbsp;', '2016-07-17 22:06:10', null, '2018-11-12 11:01:41', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, '1');
INSERT INTO `sys_module` VALUES ('AD4BC418-B66E-48C7-BC13-81590056CD15', null, null, null, '气泡图', null, null, 'iframe', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, '1');
INSERT INTO `sys_module` VALUES ('e72c75d0-3a69-41ad-b220-13c9a62ec788', '73FD1267-79BA-4E23-A152-744AF73117E9', '0', null, '数据备份', '&nbsp;', '/SystemSecurity/DbBackup/Index', 'iframe', '1', '0', '0', '0', '0', '1', null, '1', '&nbsp;', '2016-07-17 22:05:07', null, '2018-11-12 11:01:50', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, '1');
INSERT INTO `sys_module` VALUES ('F298F868-B689-4982-8C8B-9268CBF0308D', '462027E0-0848-41DD-BCC3-025DCAE65555', '0', null, '岗位管理', '&nbsp;', '/SystemManage/Duty/Index', 'iframe', '1', '0', '0', '0', '0', '40', '0', '1', '&nbsp;', null, null, '2018-11-12 11:01:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, '1');

-- ----------------------------
-- Table structure for sys_modulebutton
-- ----------------------------
DROP TABLE IF EXISTS `sys_modulebutton`;
CREATE TABLE `sys_modulebutton` (
  `F_Id` varchar(50) NOT NULL COMMENT '按钮主键',
  `F_ModuleId` varchar(50) DEFAULT NULL COMMENT '模块主键',
  `F_ParentId` varchar(50) DEFAULT NULL COMMENT '父级',
  `F_Layers` int(11) DEFAULT NULL COMMENT '层次',
  `F_EnCode` varchar(50) DEFAULT NULL COMMENT '编码',
  `F_FullName` varchar(50) DEFAULT NULL COMMENT '名称',
  `F_Icon` varchar(50) DEFAULT NULL COMMENT '图标',
  `F_Location` int(11) DEFAULT NULL COMMENT '位置',
  `F_JsEvent` varchar(50) DEFAULT NULL COMMENT '事件',
  `F_UrlAddress` text COMMENT '连接',
  `F_Split` tinyint(4) DEFAULT NULL COMMENT '分开线',
  `F_IsPublic` tinyint(4) DEFAULT NULL COMMENT '公共',
  `F_AllowEdit` tinyint(4) DEFAULT NULL COMMENT '允许编辑',
  `F_AllowDelete` tinyint(4) DEFAULT NULL COMMENT '允许删除',
  `F_SortCode` int(11) DEFAULT NULL COMMENT '排序码',
  `F_DeleteMark` tinyint(4) DEFAULT NULL COMMENT '删除标志',
  `F_EnabledMark` tinyint(4) DEFAULT NULL COMMENT '有效标志',
  `F_Description` text COMMENT '描述',
  `F_CreatorTime` datetime DEFAULT NULL COMMENT '创建日期',
  `F_CreatorUserId` varchar(50) DEFAULT NULL COMMENT '创建用户主键',
  `F_LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `F_LastModifyUserId` varchar(50) DEFAULT NULL COMMENT '最后修改用户',
  `F_DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  `F_DeleteUserId` varchar(50) DEFAULT NULL COMMENT '删除用户',
  PRIMARY KEY (`F_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='模块按钮';

-- ----------------------------
-- Records of sys_modulebutton
-- ----------------------------
INSERT INTO `sys_modulebutton` VALUES ('07d718d1-d1de-420d-8a31-1cc11d3e8f8e', '7B959522-BE45-4747-B89D-592C7F3987A5', '0', '0', 'NF-view', '查看', null, '1', null, null, '0', '0', '0', '0', '60', null, '1', null, '2018-11-03 15:58:59', null, null, null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('0816696a-975c-46fa-a240-207d8bb5b817', 'e72c75d0-3a69-41ad-b220-13c9a62ec788', '0', '0', 'NF-clear', '清除数据', null, '1', 'btn_clear()', null, '0', '0', '0', '0', '40', null, '1', null, '2018-11-13 16:50:04', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('0ce03e54-0a2f-4e2a-a6c9-da949ce488a0', 'D2ECB516-4CB7-49B1-B536-504382115DD2', '0', '0', 'NF-view', '查看列表', '&nbsp;', '1', '&nbsp;', '&nbsp;', '0', '0', '0', '0', '60', null, '1', '&nbsp;', '2018-11-03 15:58:59', null, '2018-11-05 10:52:58', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('0d777b07-041a-4205-a393-d1a009aaafc7', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '0', '0', 'NF-edit', '修改字典', '&nbsp;', '2', 'btn_edit()', '/Admin/ItemsData/Form', '0', '0', '0', '0', '3', '0', '1', '&nbsp;', null, null, '2018-11-05 10:39:12', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('0f0596f6-aa50-4df0-ad8e-af867cb4a9de', 'e72c75d0-3a69-41ad-b220-13c9a62ec788', '0', '0', 'NF-delete', '删除备份', '&nbsp;', '2', 'btn_delete()', '/Admin/DbBackup/DeleteForm', '0', '0', '0', '0', '2', '0', '1', '&nbsp;', null, null, '2018-11-05 10:49:49', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('104bcc01-0cfd-433f-87f4-29a8a3efb313', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '0', '0', 'NF-add', '新建字典', '&nbsp;', '1', 'btn_add()', '/Admin/ItemsData/Form', '0', '0', '0', '0', '1', '0', '1', '&nbsp;', null, null, '2018-11-05 10:38:54', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('13c9a15f-c50d-4f09-8344-fd0050f70086', 'F298F868-B689-4982-8C8B-9268CBF0308D', '0', '0', 'NF-add', '新建岗位', '&nbsp;', '1', 'btn_add()', '/Admin/Duty/Form', '0', '0', '0', '0', '1', '0', '1', '&nbsp;', null, null, '2018-11-05 10:44:03', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('14617a4f-bfef-4bc2-b943-d18d3ff8d22f', '38CA5A66-C993-4410-AF95-50489B22939C', '0', '0', 'NF-delete', '删除用户', '&nbsp;', '2', 'btn_delete()', '/Admin/User/DeleteForm', '0', '0', '0', '0', '3', '0', '1', '&nbsp;', null, null, '2018-11-05 10:37:43', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('15362a59-b242-494a-bc6e-413b4a63580e', '38CA5A66-C993-4410-AF95-50489B22939C', '0', '0', 'NF-disabled', '禁用', '&nbsp;', '2', 'btn_disabled()', '/Admin/User/DisabledAccount', '0', '0', '0', '0', '6', null, '1', '&nbsp;', '2016-07-25 15:25:54', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2018-11-05 10:38:04', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('1a3dc288-0956-45a5-98d3-26a0e14c720f', '5d1bfd33-1ab7-47d1-9d29-87820485960e', '0', '0', 'NF-Details', '查看参数', '&nbsp;', '2', 'btn_details()', '/Admin/Organize/Details', '0', '0', '0', '0', '4', '0', '1', '&nbsp;', null, null, '2018-11-14 11:55:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null);
INSERT INTO `sys_modulebutton` VALUES ('1ee1c46b-e767-4532-8636-936ea4c12003', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '0', '0', 'NF-delete', '删除字典', '&nbsp;', '2', 'btn_delete()', '/Admin/ItemsData/DeleteForm', '0', '0', '0', '0', '4', '0', '1', '&nbsp;', null, null, '2018-11-05 10:39:27', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('2049aea5-7d8f-4159-b871-60819d62515f', '96EE855E-8CD2-47FC-A51D-127C131C9FB9', '0', '0', 'NF-Details', '查看日志', null, '2', 'btn_details()', '/Admin/Log/Details', '0', '0', '0', '0', '20', null, '1', null, '2018-11-06 10:58:50', '16da6393-2be6-4f6c-b298-21aa586fb852', null, null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('239077ff-13e1-4720-84e1-67b6f0276979', '91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '0', '0', 'NF-delete', '删除角色', '&nbsp;', '2', 'btn_delete()', '/Admin/Role/DeleteForm', '0', '0', '0', '0', '3', '0', '1', '&nbsp;', null, null, '2018-11-05 10:42:19', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('269155fa-6aff-495d-beab-a2f067b2a311', 'D2ECB516-4CB7-49B1-B536-504382115DD2', '0', '0', 'NF-Details', '查看日志', 'fa fa fa-search-plus', '2', 'btn_details()', '/Game/Log/Details', '0', '0', '0', '0', '20', null, '1', '&nbsp;', '2018-11-01 15:16:53', null, '2018-11-05 10:52:40', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('2a8f5342-5eb7-491c-a1a9-a2631d8eb5d6', '38CA5A66-C993-4410-AF95-50489B22939C', '0', '0', 'NF-enabled', '启用', '&nbsp;', '2', 'btn_enabled()', '/Admin/User/EnabledAccount', '0', '0', '0', '0', '7', null, '1', '&nbsp;', '2016-07-25 15:28:08', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2018-11-05 10:38:18', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('2b31e390-5169-4a83-a732-913991f5297e', '91cebeab-fd99-4612-a20e-bc06befc7cb6', '0', '0', 'NF-add', '新建预设开奖', '&nbsp;', '1', 'btn_add()', '/Game/Preset/Form', '0', '0', '0', '0', '10', null, '1', '&nbsp;', '2018-11-02 14:08:44', null, '2018-11-05 10:47:40', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('2fd53dba-5c47-4cef-b58b-df9d454807e0', '39E97B05-7B6F-4069-9972-6F9643BC3042', '0', '0', 'NF-auto', '自动开奖', '&nbsp;', '1', 'btn_auto()', '/Game/Result/Auto', '0', '0', '0', '0', '20', null, '1', '&nbsp;', '2018-11-02 17:46:34', null, '2018-11-05 10:50:57', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('329c0326-ce68-4a24-904d-aade67a90fc7', 'a3a4742d-ca39-42ec-b95a-8552a6fae579', '0', '0', 'NF-Details', '查看策略', '&nbsp;', '2', 'btn_details()', '/Admin/FilterIP/Details', '0', '0', '0', '0', '4', '0', '1', '&nbsp;', null, null, '2018-11-05 10:49:18', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('38e39592-6e86-42fb-8f72-adea0c82cbc1', '38CA5A66-C993-4410-AF95-50489B22939C', '0', '0', 'NF-revisepassword', '密码重置', '&nbsp;', '2', 'btn_revisepassword()', '/Admin/User/RevisePassword', '1', '0', '0', '0', '5', null, '1', '&nbsp;', '2016-07-25 14:18:19', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2018-11-05 10:37:57', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('3a35c662-a356-45e4-953d-00ebd981cad6', '96EE855E-8CD2-47FC-A51D-127C131C9FB9', '0', '0', 'NF-removelog', '清空日志', '&nbsp;', '1', 'btn_removeLog()', '/Admin/Log/RemoveLog', '0', '0', '0', '0', '1', '0', '1', '&nbsp;', null, null, '2018-11-05 10:48:48', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('3eb10a27-9540-49e7-9d66-d371a3a6f1e3', '91cebeab-fd99-4612-a20e-bc06befc7cb6', '0', '0', 'NF-edit', '修改预设开奖', '&nbsp;', '2', 'btn_edit()', '/Game/Preset/Form', '0', '0', '0', '0', '20', null, '1', '&nbsp;', '2018-11-02 14:09:21', null, '2018-11-05 10:47:49', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('40b17b3f-dfe4-420d-a328-851e9632e992', '39E97B05-7B6F-4069-9972-6F9643BC3042', '0', '0', 'NF-manual', '手动开奖', '&nbsp;', '1', 'btn_manual()', '/Game/Result/Manual', '0', '0', '0', '0', '30', null, '1', '&nbsp;', '2018-11-03 12:13:49', null, '2018-11-05 10:51:17', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('41862743-f703-4b6d-be54-08d253eb0ebc', 'e72c75d0-3a69-41ad-b220-13c9a62ec788', '0', '0', 'NF-add', '新建备份', '&nbsp;', '1', 'btn_add()', '/Admin/DbBackup/Form', '0', '0', '0', '0', '1', '0', '1', '&nbsp;', null, null, '2018-11-05 10:49:32', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('4676833f-c9ae-4684-b551-952282851de2', '5d1bfd33-1ab7-47d1-9d29-87820485960e', '0', '0', 'NF-delete', '删除参数', '&nbsp;', '2', 'btn_delete()', '&nbsp;', '0', '0', '0', '0', '3', '0', '1', '&nbsp;', null, null, '2018-11-14 11:55:02', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null);
INSERT INTO `sys_modulebutton` VALUES ('4727adf7-5525-4c8c-9de5-39e49c268349', '38CA5A66-C993-4410-AF95-50489B22939C', '0', '0', 'NF-edit', '修改用户', '&nbsp;', '2', 'btn_edit()', '/Admin/User/Form', '0', '0', '0', '0', '2', '0', '1', '&nbsp;', null, null, '2018-11-05 10:37:32', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('48afe7b3-e158-4256-b50c-cd0ee7c6dcc9', '337A4661-99A5-4E5E-B028-861CACAF9917', '0', '0', 'NF-add', '新建区域', '&nbsp;', '1', 'btn_add()', '/Admin/Area/Form', '0', '0', '0', '0', '1', '0', '1', '&nbsp;', null, null, '2018-11-05 10:36:35', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('4b876abc-1b85-47b0-abc7-96e313b18ed8', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '0', '0', 'NF-itemstype', '分类管理', '&nbsp;', '1', 'btn_itemstype()', '/Admin/ItemsType/Index', '0', '0', '0', '0', '2', null, '1', '&nbsp;', '2016-07-25 15:36:21', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '2018-11-05 10:39:02', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('4bb19533-8e81-419b-86a1-7ee56bf1dd45', '252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '0', '0', 'NF-delete', '删除机构', '&nbsp;', '2', 'btn_delete()', '/Admin/Organize/DeleteForm', '0', '0', '0', '0', '3', '0', '1', '&nbsp;', null, null, '2018-11-05 10:35:52', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('5176dc92-42b5-4151-b899-addcb395429c', '5328e771-aab3-4967-bfb9-a7f16f0d2020', '0', '0', 'NF-disabled', '禁用', '&nbsp;', '2', 'btn_disabled()', '/Game/KillRate/disable', '0', '0', '0', '0', '50', null, '1', '&nbsp;', '2018-11-02 10:42:52', null, '2018-11-05 10:46:42', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('534852f4-0989-4bb0-aea1-b0f8e8df94c4', '39E97B05-7B6F-4069-9972-6F9643BC3042', '0', '0', 'NF-view', '查看', '&nbsp;', '1', '&nbsp;', '/Game/Result/Details', '0', '0', '0', '0', '60', null, '1', '&nbsp;', '2018-11-03 15:58:59', null, '2018-11-05 10:51:34', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('5d708d9d-6ebe-40ea-8589-e3efce9e74ec', '91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '0', '0', 'NF-add', '新建角色', '&nbsp;', '1', 'btn_add()', '/Admin/Role/Form', '0', '0', '0', '0', '1', '0', '1', '&nbsp;', null, null, '2018-11-05 10:42:03', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('64f906e4-161e-428b-8ccc-cd031b042b4a', '53df9c6b-c1e0-48c4-839b-641ce17cb217', '0', '0', 'NF-add', '新建提现', '&nbsp;', '1', 'btn_add()', '&nbsp;', '0', '0', '0', '0', '10', '0', '1', '&nbsp;', null, null, '2018-11-13 15:19:16', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null);
INSERT INTO `sys_modulebutton` VALUES ('709a4a7b-4d98-462d-b47c-351ef11db06f', '252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '0', '0', 'NF-Details', '查看机构', '&nbsp;', '2', 'btn_details()', '/Admin/Organize/Details', '0', '0', '0', '0', '4', '0', '1', '&nbsp;', null, null, '2018-11-05 10:36:02', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('74eecdfb-3bee-405d-be07-27a78219c179', '38CA5A66-C993-4410-AF95-50489B22939C', '0', '0', 'NF-add', '新建用户', '&nbsp;', '1', 'btn_add()', '/Admin/User/Form', '0', '0', '0', '0', '1', '0', '1', '&nbsp;', null, null, '2018-11-05 10:37:24', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('7b778be3-9799-42a3-8817-6b0ea992fb78', '5328e771-aab3-4967-bfb9-a7f16f0d2020', '0', '0', 'NF-enabled', '启用', '&nbsp;', '2', 'btn_enabled()', '/Game/KillRate/Enable', '0', '0', '0', '0', '40', null, '1', '&nbsp;', '2018-11-02 10:42:24', null, '2018-11-05 10:46:35', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('7e8e1b63-4a2c-4673-9574-181fba993617', '53df9c6b-c1e0-48c4-839b-641ce17cb217', '0', '0', 'NF-delete', '删除提现', '&nbsp;', '2', 'btn_delete()', '&nbsp;', '0', '0', '0', '0', '3', '0', '1', '&nbsp;', null, null, '2018-11-13 15:19:09', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null);
INSERT INTO `sys_modulebutton` VALUES ('82f162cb-beb9-4a79-8924-cd1860e26e2e', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '0', '0', 'NF-Details', '查看字典', '&nbsp;', '2', 'btn_details()', '/Admin/ItemsData/Details', '0', '0', '0', '0', '5', '0', '1', '&nbsp;', null, null, '2018-11-05 10:39:37', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('8379135e-5b13-4236-bfb1-9289e6129034', 'a3a4742d-ca39-42ec-b95a-8552a6fae579', '0', '0', 'NF-delete', '删除策略', '&nbsp;', '2', 'btn_delete()', '/Admin/FilterIP/DeleteForm', '0', '0', '0', '0', '3', '0', '1', '&nbsp;', null, null, '2018-11-05 10:49:12', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('85F5212F-E321-4124-B155-9374AA5D9C10', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '0', '0', 'NF-delete', '删除菜单', '&nbsp;', '2', 'btn_delete()', '/Admin/Menu/DeleteForm', '0', '0', '0', '0', '3', '0', '1', '&nbsp;', null, null, '2018-11-05 10:40:57', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('88f7b3a8-fd6d-4f8e-a861-11405f434868', 'F298F868-B689-4982-8C8B-9268CBF0308D', '0', '0', 'NF-Details', '查看岗位', '&nbsp;', '2', 'btn_details()', '/Admin/Duty/Details', '0', '0', '0', '0', '4', '0', '1', '&nbsp;', null, null, '2018-11-05 10:44:27', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('89d7a69d-b953-4ce2-9294-db4f50f2a157', '337A4661-99A5-4E5E-B028-861CACAF9917', '0', '0', 'NF-edit', '修改区域', '&nbsp;', '2', 'btn_edit()', '/Admin/Area/Form', '0', '0', '0', '0', '2', '0', '1', '&nbsp;', null, null, '2018-11-05 10:36:42', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('8a9993af-69b2-4d8a-85b3-337745a1f428', 'F298F868-B689-4982-8C8B-9268CBF0308D', '0', '0', 'NF-delete', '删除岗位', '&nbsp;', '2', 'btn_delete()', '/Admin/Duty/DeleteForm', '0', '0', '0', '0', '3', '0', '1', '&nbsp;', null, null, '2018-11-05 10:44:17', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('8b52246e-bab7-4f86-ac1b-49a6008c92ee', '5328e771-aab3-4967-bfb9-a7f16f0d2020', '0', '0', 'NF-edit', '修改杀率', '&nbsp;', '2', 'btn_edit()', '/Game/KillRate/Form', '0', '0', '0', '0', '20', null, '1', '&nbsp;', '2018-11-02 10:41:26', null, '2018-11-05 10:46:02', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('8c7013a9-3682-4367-8bc6-c77ca89f346b', '337A4661-99A5-4E5E-B028-861CACAF9917', '0', '0', 'NF-delete', '删除区域', '&nbsp;', '2', 'btn_delete()', '/Admin/Area/DeleteForm', '0', '0', '0', '0', '3', '0', '1', '&nbsp;', null, null, '2018-11-05 10:36:49', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('91be873e-ccb7-434f-9a3b-d312d6d5798a', '252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '0', '0', 'NF-edit', '修改机构', '&nbsp;', '2', 'btn_edit()', '/Admin/Organize/Form', '0', '0', '0', '0', '2', '0', '1', '&nbsp;', null, null, '2018-11-05 10:35:45', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('9FD543DB-C5BB-4789-ACFF-C5865AFB032C', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '0', '0', 'NF-add', '新增菜单', '&nbsp;', '1', 'btn_add()', '/Admin/Menu/Form', '0', '0', '0', '0', '1', '0', '1', '&nbsp;', null, null, '2018-11-05 10:40:45', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('a546f74b-42d2-4afd-bd03-9f5a74489dd6', '39E97B05-7B6F-4069-9972-6F9643BC3042', '0', '0', 'NF-delete', '删除结果', '&nbsp;', '2', 'btn_delete()', '/Game/Result/DeleteForm', '0', '0', '0', '0', '10', null, '1', '&nbsp;', '2018-11-01 17:49:46', null, '2018-11-05 10:50:47', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('a95bf423-f3e7-478f-941e-96712b673a06', '91cebeab-fd99-4612-a20e-bc06befc7cb6', '0', '0', 'NF-delete', '删除预设开奖', '&nbsp;', '2', 'btn_delete()', '/Game/Preset/DeleteForm', '0', '0', '0', '0', '30', null, '1', '&nbsp;', '2018-11-02 14:09:39', null, '2018-11-05 10:48:01', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('aaf58c1b-4af2-4e5f-a3e4-c48e86378191', 'a3a4742d-ca39-42ec-b95a-8552a6fae579', '0', '0', 'NF-edit', '修改策略', '&nbsp;', '2', 'btn_edit()', '/Admin/FilterIP/Form', '0', '0', '0', '0', '2', '0', '1', '&nbsp;', null, null, '2018-11-05 10:49:05', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('abfdff21-8ebf-4024-8555-401b4df6acd9', '38CA5A66-C993-4410-AF95-50489B22939C', '0', '0', 'NF-Details', '查看用户', '&nbsp;', '2', 'btn_details()', '/Admin/User/Details', '1', '0', '0', '0', '4', '0', '1', '&nbsp;', null, null, '2018-11-05 10:37:49', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('aed66cfb-d78e-43d4-9987-c714546be7eb', 'e72c75d0-3a69-41ad-b220-13c9a62ec788', '0', '0', 'NF-download', '下载备份', '&nbsp;', '2', 'btn_download()', '/Admin/DbBackup/DownloadBackup', '0', '0', '0', '0', '3', '0', '1', '&nbsp;', null, null, '2018-11-05 10:49:57', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('b4077b35-1da7-4a7f-aa9a-c0502c2daa58', '9f05e7af-120a-45a4-b8df-548ad04508fc', '0', '0', 'NF-delete', '删除充值', '&nbsp;', '2', 'btn_delete()', '&nbsp;', '0', '0', '0', '0', '3', '0', '1', '&nbsp;', null, null, '2018-11-13 15:18:41', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null);
INSERT INTO `sys_modulebutton` VALUES ('beba03ce-addd-4ae6-932d-fe8d54330f41', '822E2523-5105-4AE0-BF48-62459D3641F6', '0', '0', 'NF-delete', '删除注单', '&nbsp;', '2', 'btn_delete()', '/Game/Order/DeleteForm', '0', '0', '0', '0', '10', null, '1', '&nbsp;', '2018-11-01 18:49:43', null, '2018-11-05 10:52:13', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('c005223a-6848-4db5-af5b-201e666d7418', '7f7e2239-7c61-4ca3-94e4-56866b6919cb', '0', '0', 'NF-view', '查看', null, '1', null, null, '0', '0', '0', '0', '60', null, '1', null, '2018-11-03 15:58:59', null, null, null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('c90c4d44-a08c-4033-afc1-087284577398', 'D2ECB516-4CB7-49B1-B536-504382115DD2', '0', '0', 'NF-delete', '删除日志', 'fa fa-trash-o', '2', 'btn_delete()', '/Game/Log/DeleteForm', '0', '0', '0', '0', '10', null, '1', '&nbsp;', '2018-11-01 15:16:25', null, '2018-11-05 10:52:31', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('c98e70c2-5916-4b18-b3ad-cc5a76c9afe0', '91cebeab-fd99-4612-a20e-bc06befc7cb6', '0', '0', 'NF-view', '查看', '&nbsp;', '1', '&nbsp;', '/Game/Preset/Details', '0', '0', '0', '0', '60', null, '1', '&nbsp;', '2018-11-03 15:58:59', null, '2018-11-05 10:48:27', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('cca45eac-cf6c-4051-b319-80be89e81ca8', '91cebeab-fd99-4612-a20e-bc06befc7cb6', '0', '0', 'NF-enabled', '启用', '&nbsp;', '2', 'btn_enabled()', '/Game/Preset/Disable', '0', '0', '0', '0', '50', null, '1', '&nbsp;', '2018-11-02 14:10:49', null, '2018-11-05 10:48:18', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('cd65e50a-0bea-45a9-b82e-f2eacdbd209e', '252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '0', '0', 'NF-add', '新建机构', '&nbsp;', '1', 'btn_add()', '/Admin/Organize/Form', '0', '0', '0', '0', '1', '0', '1', '&nbsp;', null, null, '2018-11-05 10:35:37', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('d24ebe01-f794-487c-9214-baacb78eb13c', '9f05e7af-120a-45a4-b8df-548ad04508fc', '0', '0', 'NF-add', '新建充值', '&nbsp;', '1', 'btn_add()', '&nbsp;', '0', '0', '0', '0', '10', '0', '1', '&nbsp;', null, null, '2018-11-13 15:18:27', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null);
INSERT INTO `sys_modulebutton` VALUES ('d4074121-0d4f-465e-ad37-409bbe15bf8a', 'a3a4742d-ca39-42ec-b95a-8552a6fae579', '0', '0', 'NF-add', '新建策略', '&nbsp;', '1', 'btn_add()', '/Admin/FilterIP/Form', '0', '0', '0', '0', '1', '0', '1', '&nbsp;', null, null, '2018-11-05 10:48:59', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('D4FCAFED-7640-449E-80B7-622DDACD5012', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '0', '0', 'NF-Details', '查看菜单', '&nbsp;', '2', 'btn_details()', '/Admin/Menu/Details', '1', '0', '0', '0', '4', '0', '1', '&nbsp;', null, null, '2018-11-05 10:41:05', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('d80320c8-97dc-4aca-b1eb-0cea2a331f86', '822E2523-5105-4AE0-BF48-62459D3641F6', '0', '0', 'NF-view', '查看', null, '1', null, null, '0', '0', '0', '0', '60', null, '1', null, '2018-11-03 15:58:59', null, null, null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('E29FCBA7-F848-4A8B-BC41-A3C668A9005D', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '0', '0', 'NF-edit', '修改菜单', '&nbsp;', '2', 'btn_edit()', '/Admin/Menu/Form', '0', '0', '0', '0', '2', '0', '1', '&nbsp;', null, null, '2018-11-05 10:40:51', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('e57d5ab4-990d-427c-bc89-ca0d5d514810', 'fe3c9278-5c7d-4081-a205-bf0ded91e439', '0', '0', 'NF-view', '查看', null, '1', null, null, '0', '0', '0', '0', '60', null, '1', null, '2018-11-03 15:58:59', null, null, null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('e75e4efc-d461-4334-a764-56992fec38e6', 'F298F868-B689-4982-8C8B-9268CBF0308D', '0', '0', 'NF-edit', '修改岗位', '&nbsp;', '2', 'btn_edit()', '/Admin/Duty/Form', '0', '0', '0', '0', '2', '0', '1', '&nbsp;', null, null, '2018-11-05 10:44:10', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('e7eee13f-ebc0-435d-806a-2e932216eba5', '91cebeab-fd99-4612-a20e-bc06befc7cb6', '0', '0', 'NF-disabled', '禁用', '&nbsp;', '2', 'btn_disabled()', '/Game/Preset/Enable', '0', '0', '0', '0', '40', null, '1', '&nbsp;', '2018-11-02 14:10:18', null, '2018-11-05 10:48:08', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('f93763ff-51a1-478d-9585-3c86084c54f3', '91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '0', '0', 'NF-Details', '查看角色', '&nbsp;', '2', 'btn_details()', '/Admin/Role/Details', '0', '0', '0', '0', '4', '0', '1', '&nbsp;', null, null, '2018-11-05 10:42:27', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('FD3D073C-4F88-467A-AE3B-CDD060952CE6', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '0', '0', 'NF-modulebutton', '按钮管理', '&nbsp;', '2', 'btn_modulebutton()', '/Admin/Button/Index', '0', '0', '0', '0', '5', '0', '1', '&nbsp;', null, null, '2018-11-05 10:41:46', null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('fe6087ad-e334-46ab-9ac7-79e15596b221', '42fe6bcd-7e39-4606-a1c3-87e795188bc3', '0', '0', 'NF-Details', '查看', null, '1', null, null, '0', '0', '0', '0', '10', null, '1', null, '2018-11-08 15:09:50', '783ce87b-e18e-4e93-bb6c-51b5d0c3c6c6', null, null, null, null);
INSERT INTO `sys_modulebutton` VALUES ('ffffe7f8-900c-413a-9970-bee7d6599cce', '91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '0', '0', 'NF-edit', '修改角色', '&nbsp;', '2', 'btn_edit()', '/Admin/Role/Form', '0', '0', '0', '0', '2', '0', '1', '&nbsp;', null, null, '2018-11-05 10:42:12', null, null, null);

-- ----------------------------
-- Table structure for sys_moduleform
-- ----------------------------
DROP TABLE IF EXISTS `sys_moduleform`;
CREATE TABLE `sys_moduleform` (
  `F_Id` varchar(50) NOT NULL COMMENT '表单主键',
  `F_ModuleId` varchar(50) DEFAULT NULL COMMENT '模块主键',
  `F_EnCode` varchar(50) DEFAULT NULL COMMENT '编码',
  `F_FullName` varchar(50) DEFAULT NULL COMMENT '名称',
  `F_FormJson` longtext COMMENT '表单控件Json',
  `F_SortCode` int(11) DEFAULT NULL COMMENT '排序码',
  `F_DeleteMark` tinyint(4) DEFAULT NULL COMMENT '删除标志',
  `F_EnabledMark` tinyint(4) DEFAULT NULL COMMENT '有效标志',
  `F_Description` text COMMENT '描述',
  `F_CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `F_CreatorUserId` varchar(50) DEFAULT NULL COMMENT '创建用户',
  `F_LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `F_LastModifyUserId` varchar(50) DEFAULT NULL COMMENT '最后修改用户',
  `F_DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  `F_DeleteUserId` text COMMENT '删除用户',
  PRIMARY KEY (`F_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='模块表单';

-- ----------------------------
-- Records of sys_moduleform
-- ----------------------------

-- ----------------------------
-- Table structure for sys_moduleforminstance
-- ----------------------------
DROP TABLE IF EXISTS `sys_moduleforminstance`;
CREATE TABLE `sys_moduleforminstance` (
  `F_Id` varchar(50) NOT NULL COMMENT '表单实例主键',
  `F_FormId` varchar(50) NOT NULL COMMENT '表单主键',
  `F_ObjectId` varchar(50) DEFAULT NULL COMMENT '对象主键',
  `F_InstanceJson` longtext COMMENT '表单实例Json',
  `F_SortCode` int(11) DEFAULT NULL COMMENT '排序码',
  `F_CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `F_CreatorUserId` varchar(50) DEFAULT NULL COMMENT '创建用户',
  PRIMARY KEY (`F_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='模块表单实例';

-- ----------------------------
-- Records of sys_moduleforminstance
-- ----------------------------

-- ----------------------------
-- Table structure for sys_organize
-- ----------------------------
DROP TABLE IF EXISTS `sys_organize`;
CREATE TABLE `sys_organize` (
  `F_Id` varchar(50) NOT NULL COMMENT '组织主键',
  `F_ParentId` varchar(50) DEFAULT NULL COMMENT '父级',
  `F_Layers` int(11) DEFAULT NULL COMMENT '层次',
  `F_EnCode` varchar(50) DEFAULT NULL COMMENT '编码',
  `F_FullName` varchar(50) DEFAULT NULL COMMENT '名称',
  `F_ShortName` varchar(50) DEFAULT NULL COMMENT '简称',
  `F_CategoryId` varchar(50) DEFAULT NULL COMMENT '分类',
  `F_ManagerId` varchar(50) DEFAULT NULL COMMENT '负责人',
  `F_TelePhone` varchar(20) DEFAULT NULL COMMENT '电话',
  `F_MobilePhone` varchar(20) DEFAULT NULL COMMENT '手机',
  `F_WeChat` varchar(50) DEFAULT NULL COMMENT '微信',
  `F_Fax` varchar(20) DEFAULT NULL COMMENT '传真',
  `F_Email` varchar(50) DEFAULT NULL COMMENT '邮箱',
  `F_AreaId` varchar(50) DEFAULT NULL COMMENT '归属区域',
  `F_Address` text COMMENT '联系地址',
  `F_AllowEdit` tinyint(4) DEFAULT NULL COMMENT '允许编辑',
  `F_AllowDelete` tinyint(4) DEFAULT NULL COMMENT '允许删除',
  `F_SortCode` int(11) DEFAULT NULL COMMENT '排序码',
  `F_DeleteMark` tinyint(4) DEFAULT NULL COMMENT '删除标志',
  `F_EnabledMark` tinyint(4) DEFAULT NULL COMMENT '有效标志',
  `F_Description` text COMMENT '描述',
  `F_CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `F_CreatorUserId` varchar(50) DEFAULT NULL COMMENT '创建用户',
  `F_LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `F_LastModifyUserId` varchar(50) DEFAULT NULL COMMENT '最后修改用户',
  `F_DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  `F_DeleteUserId` text COMMENT '删除用户',
  PRIMARY KEY (`F_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='组织表';

-- ----------------------------
-- Records of sys_organize
-- ----------------------------
INSERT INTO `sys_organize` VALUES ('554C61CE-6AE0-44EB-B33D-A462BE7EB3E1', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '2', 'Ministry', '技术部', null, 'Department', null, null, null, null, null, null, null, null, null, null, '5', '0', '1', null, '2016-06-10 00:00:00', null, null, null, null, null);
INSERT INTO `sys_organize` VALUES ('5AB270C0-5D33-4203-A54F-4552699FDA3C', '0', '0', 'Company', '特斯拉', null, 'Group', '郭总', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;', null, '上海市松江区', '0', '0', '0', '0', '1', null, '2016-06-10 00:00:00', null, '2018-11-12 11:02:37', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null);
INSERT INTO `sys_organize` VALUES ('80E10CD5-7591-40B8-A005-BCDE1B961E76', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '0', 'Admin', '董事局', null, 'Department', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;', null, '&nbsp;', '0', '0', '0', '0', '1', null, '2016-06-10 00:00:00', null, '2018-10-31 13:02:09', null, null, null);

-- ----------------------------
-- Table structure for sys_role
-- ----------------------------
DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE `sys_role` (
  `F_Id` varchar(50) NOT NULL COMMENT '角色主键',
  `F_OrganizeId` varchar(50) DEFAULT NULL COMMENT '组织主键',
  `F_Category` int(11) DEFAULT NULL COMMENT '分类:1-角色2-岗位',
  `F_EnCode` varchar(50) DEFAULT NULL COMMENT '编号',
  `F_FullName` varchar(50) DEFAULT NULL COMMENT '名称',
  `F_Type` varchar(50) DEFAULT NULL COMMENT '类型',
  `F_AllowEdit` tinyint(4) DEFAULT NULL COMMENT '允许编辑',
  `F_AllowDelete` tinyint(4) DEFAULT NULL COMMENT '允许删除',
  `F_SortCode` int(11) DEFAULT NULL COMMENT '排序码',
  `F_DeleteMark` tinyint(4) DEFAULT NULL COMMENT '删除标志',
  `F_EnabledMark` tinyint(4) DEFAULT NULL COMMENT '有效标志',
  `F_Description` text COMMENT '描述',
  `F_CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `F_CreatorUserId` varchar(50) DEFAULT NULL COMMENT '创建用户',
  `F_LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `F_LastModifyUserId` varchar(50) DEFAULT NULL COMMENT '最后修改用户',
  `F_DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  `F_DeleteUserId` text COMMENT '删除用户',
  PRIMARY KEY (`F_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='角色表';

-- ----------------------------
-- Records of sys_role
-- ----------------------------
INSERT INTO `sys_role` VALUES ('2e200954-81ed-4212-86f1-5f3a0f6d4dcb', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '2', 'Guest', '客户', null, '0', '0', '20', null, '1', '&nbsp;', '2018-10-31 13:19:49', null, '2018-11-12 11:04:23', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null);
INSERT INTO `sys_role` VALUES ('64983d95-b596-4f65-9528-717711725253', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '2', 'Employee', '员工', null, '0', '0', '30', null, '1', '&nbsp;', '2018-10-31 13:28:11', null, '2018-10-31 13:28:20', null, null, null);
INSERT INTO `sys_role` VALUES ('c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '1', 'Guest', '访客', '3', '0', '0', '20', null, '1', '&nbsp;', '2018-10-31 13:08:56', null, '2018-11-05 12:00:29', null, null, null);
INSERT INTO `sys_role` VALUES ('CB116AA3-88CC-4CF7-B0BC-7C55EC502183', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '2', 'CEO', '首席执行官', null, '0', '0', '10', '0', '1', '&nbsp;', '2016-07-12 00:00:00', null, '2018-11-12 11:02:49', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', null, null);
INSERT INTO `sys_role` VALUES ('F0A2B36F-35A7-4660-B46C-D4AB796591EB', '5AB270C0-5D33-4203-A54F-4552699FDA3C', '1', 'admin', '超级管理员', '1', '1', '1', '1', '0', '1', '&nbsp;', '2016-07-10 00:00:00', null, '2018-11-08 15:10:06', '783ce87b-e18e-4e93-bb6c-51b5d0c3c6c6', null, null);

-- ----------------------------
-- Table structure for sys_roleauthorize
-- ----------------------------
DROP TABLE IF EXISTS `sys_roleauthorize`;
CREATE TABLE `sys_roleauthorize` (
  `F_Id` varchar(50) NOT NULL COMMENT '角色授权主键',
  `F_ItemType` int(11) DEFAULT NULL COMMENT '项目类型1-模块2-按钮3-列表',
  `F_ItemId` varchar(50) DEFAULT NULL COMMENT '项目主键',
  `F_ObjectType` int(11) DEFAULT NULL COMMENT '对象分类1-角色2-部门-3用户',
  `F_ObjectId` varchar(50) DEFAULT NULL COMMENT '对象主键',
  `F_SortCode` int(11) DEFAULT NULL COMMENT '排序码',
  `F_CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `F_CreatorUserId` varchar(50) DEFAULT NULL COMMENT '创建用户',
  PRIMARY KEY (`F_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='角色授权表';

-- ----------------------------
-- Records of sys_roleauthorize
-- ----------------------------
INSERT INTO `sys_roleauthorize` VALUES ('036dee3b-de82-4c4c-aa85-f9a76212f2de', '1', '462027E0-0848-41DD-BCC3-025DCAE65555', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('0408809f-bc38-47d7-a272-ef859ae637ca', '1', '38CA5A66-C993-4410-AF95-50489B22939C', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('055eaf41-1db7-4be3-b0d7-4343336f1702', '1', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('09d4d5c0-6274-46cd-9765-b4a5ca5476d4', '1', '423A200B-FA5F-4B29-B7B7-A3F5474B725F', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('0bc4a18b-6f8e-4f71-857a-4024b5de98b9', '2', '2fd53dba-5c47-4cef-b58b-df9d454807e0', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('0c3a82f7-dd61-495a-8756-df1df212f1da', '2', '13c9a15f-c50d-4f09-8344-fd0050f70086', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('114f1eac-60b0-4ffb-8992-8ecd15d203ae', '2', 'aed66cfb-d78e-43d4-9987-c714546be7eb', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('122fc51c-bbd2-4d2f-9a8d-f8f454b4d75b', '1', 'a3a4742d-ca39-42ec-b95a-8552a6fae579', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('126ff361-b861-42ed-b80f-e49219c4cb7e', '2', 'D4FCAFED-7640-449E-80B7-622DDACD5012', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('167cc416-83da-49f8-a9f4-df9a4bf7f1b5', '2', 'fe6087ad-e334-46ab-9ac7-79e15596b221', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('1755840c-808d-4afb-ba4f-1b40588b2e7c', '2', 'd4074121-0d4f-465e-ad37-409bbe15bf8a', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('17cd19c7-8fa0-48e5-9d11-9beed44aaaf8', '2', 'f114ece3-cb46-4bce-995e-7c81b120e33c', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('189d2365-3c35-4c46-9feb-f4d04e094e40', '1', '39E97B05-7B6F-4069-9972-6F9643BC3042', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('19686b29-974f-4709-91d6-ab905eb7c077', '2', 'c005223a-6848-4db5-af5b-201e666d7418', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('1bc0976d-ce05-4717-aa04-b6502c94222e', '2', '07d718d1-d1de-420d-8a31-1cc11d3e8f8e', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('22af8068-01a3-4432-b9f5-dc8302d69603', '2', '269155fa-6aff-495d-beab-a2f067b2a311', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('232a4980-1046-4123-b2d1-e3589bdfb291', '1', '73FD1267-79BA-4E23-A152-744AF73117E9', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('238d374c-18c7-4894-b47d-f074a6b62001', '2', '9FD543DB-C5BB-4789-ACFF-C5865AFB032C', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('2587b1d3-0486-4049-821b-a29451af4f48', '2', '0ce03e54-0a2f-4e2a-a6c9-da949ce488a0', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('28deac78-92ba-4e35-a434-a50243edfdd3', '1', 'daa7c37d-fe4e-4a67-aa75-e8df8cb0a239', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('29de0c39-c326-43fb-9e65-bd9e9dfeeb70', '2', '104bcc01-0cfd-433f-87f4-29a8a3efb313', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('2a2f5feb-ead1-4e8f-ab12-26aa11b6b3a2', '1', '91cebeab-fd99-4612-a20e-bc06befc7cb6', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('30c148bd-c32d-4367-bd3f-71f32c764571', '1', 'c74b71b7-42b4-4939-b996-2bad8d202243', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('33f39a64-6e4f-435f-a336-2b3c93ab74c0', '2', '85F5212F-E321-4124-B155-9374AA5D9C10', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('36b26b5f-a325-4c96-a9ef-3f02010a0544', '2', 'E29FCBA7-F848-4A8B-BC41-A3C668A9005D', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('3a2f6e24-5c1c-42e1-bb50-2272125bdba9', '2', 'e7eee13f-ebc0-435d-806a-2e932216eba5', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('3ac5aa68-6b79-4dae-9d54-c998ed5c46c8', '1', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('3e128599-ace5-40a6-923e-af8ae2db24d7', '1', '337A4661-99A5-4E5E-B028-861CACAF9917', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('3fa26f2a-36a0-4c00-8368-5f90461af4e3', '2', '1ee1c46b-e767-4532-8636-936ea4c12003', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('415bd86e-8328-4b3a-9969-901f69df92c4', '1', 'ed5ae7ad-6b5a-4f92-9211-6775a68997af', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('43631a58-c79b-4f16-829b-5e71e7a4b6e2', '2', 'b199f3cc-54bc-4872-90a3-2eba3dab7c91', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('477599ee-59b2-40dd-b834-94483909819b', '2', 'c98e70c2-5916-4b18-b3ad-cc5a76c9afe0', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('47adf4b2-3c47-49b1-bc6a-0e0cfa792646', '2', '48afe7b3-e158-4256-b50c-cd0ee7c6dcc9', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('47e5836d-98a0-4805-b8b3-8ebaba706666', '2', '82f162cb-beb9-4a79-8924-cd1860e26e2e', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('48cd9ce6-0e20-4205-a5dd-37622d0fbf10', '1', '39E97B05-7B6F-4069-9972-6F9643BC3042', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('49792c74-0de0-4ddf-a034-a0c9c57c9bf3', '2', '4727adf7-5525-4c8c-9de5-39e49c268349', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('49a8e587-b9b5-4bc7-8239-3b0db36bda5a', '2', '0d777b07-041a-4205-a393-d1a009aaafc7', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('4a1e6a85-fa23-44a6-b676-9da9ce95ed3c', '1', '822E2523-5105-4AE0-BF48-62459D3641F6', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('4b054245-cec7-45b0-99fa-22f1802fa575', '2', '0f0596f6-aa50-4df0-ad8e-af867cb4a9de', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('4c80cb06-bef7-4a14-be2f-4fbb26cfde50', '2', 'a546f74b-42d2-4afd-bd03-9f5a74489dd6', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('4d857dcc-059c-4d5f-a985-65d15ee0c559', '2', '5176dc92-42b5-4151-b899-addcb395429c', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('4ee15c97-0ce6-4ad1-bc47-b3104b5a832c', '2', '2b31e390-5169-4a83-a732-913991f5297e', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('5137a7a8-2e8b-455a-89c6-3f7b482f3405', '1', '7B959522-BE45-4747-B89D-592C7F3987A5', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('5473d61d-c1ac-4d93-9ba6-a4208bc2ddda', '2', 'c98e70c2-5916-4b18-b3ad-cc5a76c9afe0', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('55da5407-4525-4761-823e-84041acd2e24', '2', '2049aea5-7d8f-4159-b871-60819d62515f', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('57ad9ed3-86e4-4e37-b120-f83dc81d8e07', '2', '8c7013a9-3682-4367-8bc6-c77ca89f346b', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('59dd7ad6-fd2a-4e8f-bc83-f4b6a6685b2a', '2', '91be873e-ccb7-434f-9a3b-d312d6d5798a', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('5aac01ca-f72b-4777-9616-5247c82dd5cd', '2', '329c0326-ce68-4a24-904d-aade67a90fc7', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('5afa5729-4622-4b46-ba07-b2eb74b48f58', '1', '7f7e2239-7c61-4ca3-94e4-56866b6919cb', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('5b5fe0b3-a54f-45b8-b239-84272015c02e', '1', '9f870ac0-d34f-4146-951e-a01fa5a80fe1', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('5cac2bdc-960d-425f-8d95-0ce07bcdbe51', '1', '5328e771-aab3-4967-bfb9-a7f16f0d2020', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('61ad11a9-c098-4b32-81e1-b30e0395699b', '1', '822E2523-5105-4AE0-BF48-62459D3641F6', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('685872f2-ca13-470f-8931-d8afeec5b40c', '2', '89d7a69d-b953-4ce2-9294-db4f50f2a157', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('68cbd588-658b-44dd-9f6b-9c02ae735cd8', '2', 'FD3D073C-4F88-467A-AE3B-CDD060952CE6', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('6bbabe72-b899-4126-9c12-b198d34b06a1', '1', '7B959522-BE45-4747-B89D-592C7F3987A5', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('716713f0-b9b1-4998-bdc2-89691473af3a', '2', '14617a4f-bfef-4bc2-b943-d18d3ff8d22f', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('72a4cd60-07f4-4bd8-b6c0-bda3a56a7239', '2', '74eecdfb-3bee-405d-be07-27a78219c179', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('7583af37-fcbe-4140-83b2-329ffbb39011', '1', '9F56840F-DF92-4936-A48C-8F65A39291A2', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('7687ed3d-135c-4d0d-9dee-f0fa802189d0', '2', '534852f4-0989-4bb0-aea1-b0f8e8df94c4', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('78ab0934-c351-4454-b5ab-0ac35c514d1f', '2', 'e5ee91bd-8945-4887-bb7e-28e858c20252', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('7a8d0e86-c660-4465-afaa-aa5322090236', '1', 'c74b71b7-42b4-4939-b996-2bad8d202243', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('7dd24f99-d1af-4497-a3b3-ba7453bd3ddc', '1', '462027E0-0848-41DD-BCC3-025DCAE65555', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('80070229-88fd-42e5-9a46-6a260dc16170', '2', 'aaf58c1b-4af2-4e5f-a3e4-c48e86378191', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('81783b34-c3c2-4b4c-ae2b-7bd97bdcb094', '2', '239077ff-13e1-4720-84e1-67b6f0276979', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('81fb841c-4e72-4a06-9369-ee3bfc8dbc83', '2', 'c005223a-6848-4db5-af5b-201e666d7418', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('84b48bc6-3aa9-46f2-b942-3480819c61d2', '1', 'e72c75d0-3a69-41ad-b220-13c9a62ec788', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('85108a9f-366e-4bdf-b325-227fbc143e19', '1', '252229DB-35CA-47AE-BDAE-C9903ED5BA7B', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('87f7838d-5c51-4f14-a277-b701780cc8c8', '2', '8379135e-5b13-4236-bfb1-9289e6129034', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('89212a23-3a8c-47b4-a4b7-a850c2159824', '2', '8a9993af-69b2-4d8a-85b3-337745a1f428', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('894fdd73-0862-439b-9be9-b7cae6e42125', '2', 'cd65e50a-0bea-45a9-b82e-f2eacdbd209e', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('8dc1f6fa-2b0c-45fa-a670-3cc1762a75a3', '1', '7f7e2239-7c61-4ca3-94e4-56866b6919cb', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('8fa8c782-f577-4a09-b706-9047cd266772', '2', 'f114ece3-cb46-4bce-995e-7c81b120e33c', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('91d4bad0-d583-4106-a820-3aa5bd44f445', '1', '64A1C550-2C61-4A8C-833D-ACD0C012260F', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('94eccee6-2d15-4245-a8f4-6c74ae6cf58b', '2', '5d708d9d-6ebe-40ea-8589-e3efce9e74ec', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('99051192-91a2-4aa6-bf61-640ad9919d7d', '2', '2a8f5342-5eb7-491c-a1a9-a2631d8eb5d6', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('99a17fb6-4e96-4e70-ad55-d6daf27e42d0', '2', '4bb19533-8e81-419b-86a1-7ee56bf1dd45', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('9ddd4ed2-b3f5-44bf-b014-cb7fac4e8c12', '1', '91cebeab-fd99-4612-a20e-bc06befc7cb6', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('9e259858-16e0-420e-921f-d81555833c99', '1', '9f870ac0-d34f-4146-951e-a01fa5a80fe1', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('9f846184-3a7f-4b15-a16d-295834cf3bc1', '2', '15362a59-b242-494a-bc6e-413b4a63580e', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('a2c54ae5-c1a1-45ae-b248-44e10877c5fa', '2', '88f7b3a8-fd6d-4f8e-a861-11405f434868', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('a5746674-b886-4073-a171-1929625b9148', '2', 'c90c4d44-a08c-4033-afc1-087284577398', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('a5f0c94f-06df-478e-8ada-138b3bdc7fbb', '1', 'ed5ae7ad-6b5a-4f92-9211-6775a68997af', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('a9856f79-86da-46ee-9491-2577584b2411', '2', '40b17b3f-dfe4-420d-a328-851e9632e992', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('a99b7f35-cd20-4240-8746-35b0dc32f40f', '1', '96EE855E-8CD2-47FC-A51D-127C131C9FB9', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('ac775097-d2a8-4e92-a86b-2e8ccf39ec8d', '1', 'fe3c9278-5c7d-4081-a205-bf0ded91e439', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('afa5a453-cd5e-4d16-ad77-5d0b3b1fbe73', '1', '91A6CFAD-B2F9-4294-BDAE-76DECF412C6C', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('b02676c9-c122-486d-80a1-ff4343832b87', '2', '3eb10a27-9540-49e7-9d66-d371a3a6f1e3', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('b2ba3fb9-acf4-4f39-9f4d-2476143cd8fd', '2', '269155fa-6aff-495d-beab-a2f067b2a311', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('b702033e-07d8-420e-ac3d-689990b7cbcf', '1', '5328e771-aab3-4967-bfb9-a7f16f0d2020', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('bc1fc380-852b-418d-b80d-a0559dbaa677', '1', 'fe3c9278-5c7d-4081-a205-bf0ded91e439', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('c22a9e2d-0a93-4b8d-8369-22fe911daf63', '2', 'e57d5ab4-990d-427c-bc89-ca0d5d514810', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('c4b20f4c-aa0d-47f1-b579-5bbcfa3b4e95', '2', '82f162cb-beb9-4a79-8924-cd1860e26e2e', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('c61b0524-c830-413b-bd49-fee64c955811', '2', 'beba03ce-addd-4ae6-932d-fe8d54330f41', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('c92cb527-2465-4bb6-9b96-9fb532c51578', '2', '709a4a7b-4d98-462d-b47c-351ef11db06f', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('c9828a79-c117-4142-993d-dc01815e715e', '2', 'abfdff21-8ebf-4024-8555-401b4df6acd9', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('c99a3de3-eb78-408e-b0ca-b44d676f2483', '1', 'D2ECB516-4CB7-49B1-B536-504382115DD2', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('c9a3d179-aa1a-4bd8-8339-4f01c137b538', '2', '3a35c662-a356-45e4-953d-00ebd981cad6', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('cbe7492e-e5bd-4e04-8ec9-068d54be95e2', '1', '42fe6bcd-7e39-4606-a1c3-87e795188bc3', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('d0fab19e-d567-40ae-9fc1-3f0552bf6ace', '2', 'd80320c8-97dc-4aca-b1eb-0cea2a331f86', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('d20d65b7-263b-4259-8187-891792ca77b4', '2', 'f93763ff-51a1-478d-9585-3c86084c54f3', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('d2b9ab61-ee30-444e-9ab9-edc7b000518a', '2', 'cca45eac-cf6c-4051-b319-80be89e81ca8', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('d923c431-4811-4e82-9201-ef0f0371a814', '2', 'ffffe7f8-900c-413a-9970-bee7d6599cce', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('e1543723-27d5-404d-8b09-8bf6841d58c5', '1', '9F56840F-DF92-4936-A48C-8F65A39291A2', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('e26a0823-6f81-4a3d-8ae0-e31e40d20e0b', '1', 'D2ECB516-4CB7-49B1-B536-504382115DD2', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('e31b1c6e-332e-4de1-9cc4-c9247ba298a1', '2', '7b778be3-9799-42a3-8817-6b0ea992fb78', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('e31dc76b-ee9f-4d47-802f-30c9dfba4472', '2', 'd80320c8-97dc-4aca-b1eb-0cea2a331f86', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('e3a80013-1a08-4c76-b2c8-1ac0beb2b767', '2', '07d718d1-d1de-420d-8a31-1cc11d3e8f8e', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('e6965c5f-cd6b-4af0-a8d0-9b19a1d50edf', '2', 'e57d5ab4-990d-427c-bc89-ca0d5d514810', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('e6b0d164-9cc2-4488-9c24-caf3fb73c398', '2', '41862743-f703-4b6d-be54-08d253eb0ebc', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('e6da0ce4-2c2c-45b2-9eea-49c7e839faff', '2', 'a95bf423-f3e7-478f-941e-96712b673a06', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('efdea1e2-d89c-4d71-9b4d-de4bef0ff029', '1', '51174D27-3001-4CCF-AAB2-0AA2A6CEAA50', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('f09a1908-9f9a-4346-b3b3-40dcdb3e523d', '2', '534852f4-0989-4bb0-aea1-b0f8e8df94c4', '1', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('f0a5d37d-b483-4238-8a30-eebe4df94dab', '2', 'e75e4efc-d461-4334-a764-56992fec38e6', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('f2422891-cba3-4780-b0fa-009135f0724e', '2', '4b876abc-1b85-47b0-abc7-96e313b18ed8', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('f458ed0c-3155-43c4-8419-d7e367f884e8', '2', '0ce03e54-0a2f-4e2a-a6c9-da949ce488a0', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('fa0fefd4-46ff-4017-97eb-c3594a192a87', '2', '8b52246e-bab7-4f86-ac1b-49a6008c92ee', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('fcb7086a-dea4-4885-99f7-2334b1e4a4d0', '1', 'F298F868-B689-4982-8C8B-9268CBF0308D', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);
INSERT INTO `sys_roleauthorize` VALUES ('fd124749-4d4d-4bd7-94ea-f76201e6e13a', '2', '38e39592-6e86-42fb-8f72-adea0c82cbc1', '1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', '0', null, null);

-- ----------------------------
-- Table structure for sys_user
-- ----------------------------
DROP TABLE IF EXISTS `sys_user`;
CREATE TABLE `sys_user` (
  `F_Id` varchar(50) NOT NULL COMMENT '用户主键',
  `F_Account` varchar(50) DEFAULT NULL COMMENT '账户',
  `F_RealName` varchar(50) DEFAULT NULL COMMENT '姓名',
  `F_NickName` varchar(50) DEFAULT NULL COMMENT '呢称',
  `F_HeadIcon` varchar(50) DEFAULT NULL COMMENT '头像',
  `F_Gender` tinyint(4) DEFAULT NULL COMMENT '性别',
  `F_Birthday` datetime DEFAULT NULL COMMENT '生日',
  `F_MobilePhone` varchar(20) DEFAULT NULL COMMENT '手机',
  `F_Email` varchar(50) DEFAULT NULL COMMENT '邮箱',
  `F_WeChat` varchar(50) DEFAULT NULL COMMENT '微信',
  `F_ManagerId` varchar(50) DEFAULT NULL COMMENT '主管主键',
  `F_SecurityLevel` int(11) DEFAULT NULL COMMENT '安全级别',
  `F_Signature` text COMMENT '个性签名',
  `F_OrganizeId` varchar(50) DEFAULT NULL COMMENT '组织主键',
  `F_DepartmentId` text COMMENT '部门主键',
  `F_RoleId` text COMMENT '角色主键',
  `F_DutyId` text COMMENT '岗位主键',
  `F_IsAdministrator` tinyint(4) DEFAULT NULL COMMENT '是否管理员',
  `F_SortCode` int(11) DEFAULT NULL COMMENT '排序码',
  `F_DeleteMark` tinyint(4) DEFAULT NULL COMMENT '删除标志',
  `F_EnabledMark` tinyint(4) DEFAULT NULL COMMENT '有效标志',
  `F_Description` text COMMENT '描述',
  `F_CreatorTime` datetime DEFAULT NULL COMMENT '创建时间',
  `F_CreatorUserId` varchar(50) DEFAULT NULL COMMENT '创建用户',
  `F_LastModifyTime` datetime DEFAULT NULL COMMENT '最后修改时间',
  `F_LastModifyUserId` varchar(50) DEFAULT NULL COMMENT '最后修改用户',
  `F_DeleteTime` datetime DEFAULT NULL COMMENT '删除时间',
  `F_DeleteUserId` text COMMENT '删除用户',
  PRIMARY KEY (`F_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of sys_user
-- ----------------------------
INSERT INTO `sys_user` VALUES ('9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', 'admin', '超级管理员', null, null, '1', '0001-01-01 00:00:00', '13600000000', '&nbsp;', '&nbsp;', null, '0', null, '5AB270C0-5D33-4203-A54F-4552699FDA3C', '554C61CE-6AE0-44EB-B33D-A462BE7EB3E1', 'F0A2B36F-35A7-4660-B46C-D4AB796591EB', 'CB116AA3-88CC-4CF7-B0BC-7C55EC502183', '0', '0', '0', '1', '系统管理员', '2016-07-20 00:00:00', null, '2018-11-03 11:33:54', null, null, null);
INSERT INTO `sys_user` VALUES ('f290b18b-ad12-48f7-a100-cb7edfd35251', 'guest', '访客', null, null, '1', '2018-10-31 00:00:00', null, null, null, null, '0', null, '5AB270C0-5D33-4203-A54F-4552699FDA3C', '5AB270C0-5D33-4203-A54F-4552699FDA3C', 'c8f5d1d8-bbdc-4cdd-89f2-51c641076d77', '2e200954-81ed-4212-86f1-5f3a0f6d4dcb', '1', '0', null, '1', null, '2018-10-31 13:22:15', null, null, null, null, null);

-- ----------------------------
-- Table structure for sys_userlogon
-- ----------------------------
DROP TABLE IF EXISTS `sys_userlogon`;
CREATE TABLE `sys_userlogon` (
  `F_Id` varchar(50) NOT NULL COMMENT '用户登录主键',
  `F_UserId` varchar(50) DEFAULT NULL COMMENT '用户主键',
  `F_UserPassword` varchar(50) DEFAULT NULL COMMENT '用户密码',
  `F_UserSecretkey` varchar(50) DEFAULT NULL COMMENT '用户秘钥',
  `F_AllowStartTime` datetime DEFAULT NULL COMMENT '允许登录时间开始',
  `F_AllowEndTime` datetime DEFAULT NULL COMMENT '允许登录时间结束',
  `F_LockStartDate` datetime DEFAULT NULL COMMENT '暂停用户开始日期',
  `F_LockEndDate` datetime DEFAULT NULL COMMENT '暂停用户结束日期',
  `F_FirstVisitTime` datetime DEFAULT NULL COMMENT '第一次访问时间',
  `F_PreviousVisitTime` datetime DEFAULT NULL COMMENT '上一次访问时间',
  `F_LastVisitTime` datetime DEFAULT NULL COMMENT '最后访问时间',
  `F_ChangePasswordDate` datetime DEFAULT NULL COMMENT '最后修改密码日期',
  `F_MultiUserLogin` tinyint(4) DEFAULT NULL COMMENT '允许同时有多用户登录',
  `F_LogOnCount` int(11) DEFAULT NULL COMMENT '登录次数',
  `F_UserOnLine` tinyint(4) DEFAULT NULL COMMENT '在线状态',
  `F_Question` varchar(50) DEFAULT NULL COMMENT '密码提示问题',
  `F_AnswerQuestion` text COMMENT '密码提示答案',
  `F_CheckIPAddress` tinyint(4) DEFAULT NULL COMMENT '是否访问限制',
  `F_Language` varchar(50) DEFAULT NULL COMMENT '系统语言',
  `F_Theme` varchar(50) DEFAULT NULL COMMENT '系统样式',
  PRIMARY KEY (`F_Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户登录信息表';

-- ----------------------------
-- Records of sys_userlogon
-- ----------------------------
INSERT INTO `sys_userlogon` VALUES ('9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '9f2ec079-7d0f-4fe2-90ab-8b09a8302aba', '24cdbc1923c229e41a05a7bf3282b6fe', '57d3031d6fc4a34d', null, null, null, null, null, '2018-11-21 08:50:24', '2018-11-21 11:30:02', null, null, '261', null, null, null, null, null, null);
INSERT INTO `sys_userlogon` VALUES ('d0cd28eb-ffee-44f7-b130-070c31d8819b', 'd0cd28eb-ffee-44f7-b130-070c31d8819b', '8625f83565ad606742925ceca70470df', 'f951b31dba32f0b2', null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
INSERT INTO `sys_userlogon` VALUES ('f290b18b-ad12-48f7-a100-cb7edfd35251', 'f290b18b-ad12-48f7-a100-cb7edfd35251', 'bcd250fb5c14594e96e380bf18f44bc2', 'fb8b35ccc48023646ede75b7656da158', null, null, null, null, null, '2018-11-05 18:48:29', '2018-11-06 10:30:33', null, null, '10', null, null, null, null, null, null);

-- ----------------------------
-- Procedure structure for SP_Pagination
-- ----------------------------
DROP PROCEDURE IF EXISTS `SP_Pagination`;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `SP_Pagination`(in tbName varchar(20),#表名  
    in returnField varchar(100),#要显示的列名  
    in queryStr varchar(500),#where条件(只需要写where后面的语句)  
    in orderField varchar(500),#排序字段  
    in pageSize int,#每一页显示的记录数  
    in pageIndex int,#当前页  
    out itemCount int,
    out pageCount int)
BEGIN  
    if (pageSize < 1)then  
      set pageSize = 20;  
    end if;  
      
    if (pageIndex < 1)then  
      set pageIndex = 1;  
    end if;  
      
    if(LENGTH(queryStr)>0)then  
        set queryStr=CONCAT(' where ',queryStr);  
    end if;  
      
    if(orderField is not null and LENGTH(orderField)>0)then  
        set orderField = CONCAT(' order by ', orderField);  
    end if;  
      
    set @strsql = CONCAT('select ', returnField, ' from ', tbName, ' ', queryStr, ' ', orderField, ' limit ', pageIndex * pageSize - pageSize, ',', pageSize);  
      
    prepare stmtsql from @strsql;  
    execute stmtsql;  
    deallocate prepare stmtsql;  
      
    set @strsqlcount=concat('select count(1) as count into @itemCount from ',tbName,'',queryStr);  
    prepare stmtsqlcount from @strsqlcount;  
    execute stmtsqlcount;  
    deallocate prepare stmtsqlcount;  
    set itemCount=@itemCount;  
    set pageCount = (itemCount + pageIndex - 1) / pageSize;
END
;;
DELIMITER ;
