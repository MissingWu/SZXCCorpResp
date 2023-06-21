using System;
using System.Collections.Generic;
using System.Linq;

using System.Windows.Forms;
using CPublicDefine;
using Core.Camera;
using System.Data;
using System.Diagnostics;
using VisionCore.Tools;
using System.Reflection;
using System.Runtime.InteropServices;
using ShowControl;
using OpenCVCore;

using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using VisionCore.core.UserDefine;
using VisionCore.Log4Net;
using SZXCArimEngine;
using System.Drawing;

namespace VisionCore.core
{
    /// <summary>
    /// 目前支持的函数
    /// </summary>
    public class HMeasureSet
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<F_CELL_DATA> m_HMeasureVariables;

        /// <summary>
        /// 
        /// </summary>
        public static List<F_CELL_DATA> m_HMeasureg_Variables;

        /// <summary>
        /// 图像转换
        /// </summary>
        /// <param name="hobject">输入图像</param>
        /// <param name="image">输出图像</param>
        public static void HobjectToHimage(HObject hobject, ref HImage image)
        {
            HTuple pointer, type, width, height;
            HOperatorSet.GetImagePointer1(hobject, out pointer, out type, out width, out height);
            image.GenImage1(type, width, height, pointer);
        }
        /// <summary>
        /// 查到数据列表中的图像
        /// </summary>
        /// <param name="inVariableList">输入变量列表</param>
        /// <param name="outVariableIMGlist">输出变量列表</param>
        public static void getVariableImageList(List<F_CELL_DATA> inVariableList, out List<F_CELL_DATA> outVariableIMGlist)
        {
            IEnumerable<F_CELL_DATA> resultList = from datacell in inVariableList
                                                  where datacell.m_Data_Type == DataType.图像
                                                  select datacell;
            outVariableIMGlist = resultList.ToList();
        }
        /// <summary>
        /// 查到数据列表中的图像输出列表字符串
        /// </summary>
        /// <param name="inVariableList">输入变量列表</param>
        /// <param name="outVariableIMGlist">输出变量列表</param>
        public static void getVariableImageListString(List<F_CELL_DATA> inVariableList, out List<string > outVariableIMGStringlist)
        {
            IEnumerable<F_CELL_DATA> resultList = from datacell in inVariableList
                                                  where datacell.m_Data_Type == DataType.图像 || datacell.m_Data_Type == DataType.ThreeD图像
												  select datacell;
            outVariableIMGStringlist = new List<string>();
            foreach (F_CELL_DATA data_ in resultList)
            {
                outVariableIMGStringlist.Add(data_.m_Module_Name + ":" + data_.m_Data_Name);
            }

        }

        /// <summary>
        /// 查到数据列表中的图像输出列表字符串
        /// </summary>
        /// <param name="inVariableList">输入变量列表</param>
        /// <param name="outVariableIMGlist">输出变量列表</param>
        public static void getVariableRegionListString(List<F_CELL_DATA> inVariableList, out List<string> outVariableIMGStringlist)
        {
            IEnumerable<F_CELL_DATA> resultList = from datacell in inVariableList
                                                  where datacell.m_Data_Type == DataType.区域
                                                  select datacell;
            outVariableIMGStringlist = new List<string>();
            foreach (F_CELL_DATA data_ in resultList)
            {
                outVariableIMGStringlist.Add(data_.m_Module_Name + ":" + data_.m_Data_Name);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inVariableList"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object getVariableValue(List<F_CELL_DATA> inVariableList,string name )
        {
            object data = new object();
            try
            {
                string[] data_ = name.Split(':');
                data = null;
                F_CELL_DATA data_v = inVariableList.FirstOrDefault(c => (c.m_Module_Name == data_[0] && c.m_Data_Name == data_[1]));
                data = data_v.m_Data_Value;
               
            }
            catch(Exception ex)
            {
                DisplayMsg.SendLog(LogLevel.Error, name +"查找图像失败！");
                data = null;
                Debug.Write(ex.Message); Log.Error(ex.ToString());
            }
            return data;

        }
        /// <summary>
        /// 通过单元ID和名称查找变量列表
        /// </summary>
        /// <param name="inVariableList">输入列表</param>
        /// <param name="inCellID">单元ID</param>
        /// <param name="inVariableName">变量名称</param>
        /// <param name="outList">输出变量列表</param>
        public static void getVariableList(List<F_CELL_DATA> inVariableList, int inCellID, string inVariableName, out List<F_CELL_DATA> outList)
        {
            try
            {
                outList = new List<F_CELL_DATA>();
                //查找对应的直线
                IEnumerable<F_CELL_DATA> resultList = from datacell in inVariableList
                                                      where datacell.m_Data_CellID == inCellID
                                                           && datacell.m_Data_Name == inVariableName
                                                      select datacell;
                outList = resultList.ToList();
            }
            catch (System.Exception ex)
            {
                outList = new List<F_CELL_DATA>();
                Debug.Write(ex.Message); Log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 更新全局变量列表中的值
        /// </summary>
        /// <param name="_CellID">单元ID</param>
        /// <param name="_DataName">变量名称</param>
        /// <param name="_ListValue">newValue</param>
        public static void UpdateVariableValue(ref List<F_CELL_DATA> VariableList, int _CellID, string _DataName, object _ListValue)
        {
            int index = VariableList.FindIndex(e => e.m_Data_CellID == _CellID && e.m_Data_Name.ToUpper() == _DataName.Trim().ToUpper());

            if (index > -1)
            {
                //F_CELL_DATA datacell = VariableList.FirstOrDefault(e => e.m_Data_CellID == _CellID && e.m_Data_Name == _DataName);
                F_CELL_DATA datacell = VariableList[index];
                datacell.m_Data_Value = _ListValue;
                VariableList[index] = datacell;
            }
            //else
            //{
            //    F_CELL_DATA datacell = new F_CELL_DATA();
            //    VariableList.Add(datacell);
            //}
        }
        /// <summary>
        /// 更新全局变量列表中的值
        /// </summary>
        /// <param name="VariableList">列表</param>
        /// <param name="data">值</param>
        public static void UpdateVariableValue(ref List<F_CELL_DATA> VariableList, F_CELL_DATA data)
        {
            int index = VariableList.FindIndex(e => e.m_Data_CellID == data.m_Data_CellID && e.m_Data_Name == data.m_Data_Name);
            if (index > -1)
                VariableList[index] = data;
            else
                VariableList.Add(data);
        }
        /// <summary>
        /// 检测直线 增加屏蔽区域 magical20171028
        /// </summary>
        /// <param name="inImage">检测图像</param>
        /// <param name="inLine">输入检测直线区域</param>
        /// <param name="inMetrology">形态参数</param>
        /// <param name="outLine">输出直线</param>
        /// <param name="outR">输出行点</param>
        /// <param name="outC">输出列点</param>
        /// <param name="outMeasureXLD">输出检测轮廓</param>
        /// <param name="disableRegion">屏蔽区域 可选</param>
        /// <param name="isPaint">对屏蔽区域进行喷绘 可选</param>
        public static void MeasureLine(HImage inImage, Line_INFO inLine, Metrology_INFO inMetrology, out Line_INFO outLine, out HTuple outR, out HTuple outC, out HXLDCont outMeasureXLD, HRegion disableRegion = null)
        {
            HMetrologyModel hMetrologyModel = new HMetrologyModel();
            try
            {
                outLine = new Line_INFO();
                HTuple lineResult = new HTuple();
                HTuple lineInfo = new HTuple();
                lineInfo.Append(new HTuple(new double[] { inLine.StartY, inLine.StartX, inLine.EndY, inLine.EndX }));

                //magical 20180405增加最强边的计算
                if (inMetrology.ParamValue[1] == "strongest")
                {
                    MeasureLine1D(inImage, inLine, inMetrology, out outLine, out outR, out outC, out outMeasureXLD, disableRegion);
                    return;
                }

                hMetrologyModel.AddMetrologyObjectGeneric(new HTuple("line"), lineInfo, new HTuple(inMetrology.Length1),
                    new HTuple(inMetrology.Length2), new HTuple(1), new HTuple(inMetrology.Threshold)
                    , inMetrology.ParamName, inMetrology.ParamValue);
                hMetrologyModel.SetMetrologyObjectParam(0, "min_score", 0.1);//降低直线拟合的最低得分,尽量使用halcon的拟合方法,因为VBA_Function.fitLine方法拟合的直线不准 magical 20171018


                if (disableRegion != null && disableRegion.IsInitialized())
                {
                    hMetrologyModel.ApplyMetrologyModel(inImage);

                    //单个测量区域 刚好 有一大半在屏蔽区域,一小部分在有效区域,这时候也会测出一个点,这个点在屏蔽区域内,导致精度损失约为1个像素左右.需要喷绘之后,再进行点是否在屏蔽区域判断
                    outMeasureXLD = hMetrologyModel.GetMetrologyObjectMeasures("all", "all", out outR, out outC);

                    List<double> tempOutR = new List<double>(), tempOutC = new List<double>();

                    for (int i = 0; i < outR.DArr.Length - 1; i++)
                    {
                        //0 表示没有包含
                        if (disableRegion.TestRegionPoint(outR[i].D, outC[i].D) == 0)
                        {
                            tempOutR.Add(outR[i].D);
                            tempOutC.Add(outC[i].D);
                        }
                    }
                    outR = new HTuple(tempOutR.ToArray());
                    outC = new HTuple(tempOutC.ToArray());
                }
                else
                {
                    hMetrologyModel.ApplyMetrologyModel(inImage);
                    outMeasureXLD = hMetrologyModel.GetMetrologyObjectMeasures("all", "all", out outR, out outC);
                }
                lineResult = hMetrologyModel.GetMetrologyObjectResult(new HTuple("all"), new HTuple("all"), new HTuple("result_type"), new HTuple("all_param"));
                if (lineResult.TupleLength() >= 4)
                {
                    outLine = new Line_INFO(lineResult[0].D, lineResult[1].D, lineResult[2].D, lineResult[3].D);
                }
                else
                {
                    if (fitLineByH(outR.ToDArr().ToList(), outC.ToDArr().ToList(), out outLine))
                        outLine = inLine;
                }

                hMetrologyModel.Dispose();
            }
            catch (Exception ex)
            {
                outLine = inLine;
                outR = new HTuple();
                outC = new HTuple();
                outMeasureXLD = new HXLDCont();
                hMetrologyModel.Dispose();
                Debug.Write(ex.Message); Log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 检测矩形 增加屏蔽区域 magical20171028
        /// </summary>
        /// <param name="inImage">检测图像</param>
        /// <param name="inLine">输入检测直线区域</param>
        /// <param name="inMetrology">形态参数</param>
        /// <param name="outLine">输出直线</param>
        /// <param name="outR">输出行点</param>
        /// <param name="outC">输出列点</param>
        /// <param name="outMeasureXLD">输出检测轮廓</param>
        /// <param name="disableRegion">屏蔽区域 可选</param>
        /// <param name="isPaint">对屏蔽区域进行喷绘 可选</param>
        public static void MeasureRect(HImage inImage, Rectangle_INFO inLine, Metrology_INFO inMetrology, out Rectangle_INFO outLine, out HTuple outR, out HTuple outC, out HXLDCont outMeasureXLD, HRegion disableRegion = null)
        {
            HMetrologyModel hMetrologyModel = new HMetrologyModel();
            try
            {
                outLine = new Rectangle_INFO();
                HTuple lineResult = new HTuple();
                HTuple lineInfo = new HTuple();
                lineInfo.Append(new HTuple(new double[] { inLine.StartY, inLine.StartX, inLine.EndY, inLine.EndX }));

                //magical 20180405增加最强边的计算
                if (inMetrology.ParamValue[1] == "strongest")
                {
                    //MeasureLine1D(inImage, inLine, inMetrology, out outLine, out outR, out outC, out outMeasureXLD, disableRegion);
                   // return;
                }

                hMetrologyModel.AddMetrologyObjectGeneric(new HTuple("rectangle2"), lineInfo, new HTuple(inMetrology.Length1),
                    new HTuple(inMetrology.Length2), new HTuple(1), new HTuple(inMetrology.Threshold)
                    , inMetrology.ParamName, inMetrology.ParamValue);
                hMetrologyModel.SetMetrologyObjectParam(0, "min_score", 0.1);//降低直线拟合的最低得分,尽量使用halcon的拟合方法,因为VBA_Function.fitLine方法拟合的直线不准 magical 20171018


                if (disableRegion != null && disableRegion.IsInitialized())
                {
                    hMetrologyModel.ApplyMetrologyModel(inImage);

                    //单个测量区域 刚好 有一大半在屏蔽区域,一小部分在有效区域,这时候也会测出一个点,这个点在屏蔽区域内,导致精度损失约为1个像素左右.需要喷绘之后,再进行点是否在屏蔽区域判断
                    outMeasureXLD = hMetrologyModel.GetMetrologyObjectMeasures("all", "all", out outR, out outC);

                    List<double> tempOutR = new List<double>(), tempOutC = new List<double>();

                    for (int i = 0; i < outR.DArr.Length - 1; i++)
                    {
                        //0 表示没有包含
                        if (disableRegion.TestRegionPoint(outR[i].D, outC[i].D) == 0)
                        {
                            tempOutR.Add(outR[i].D);
                            tempOutC.Add(outC[i].D);
                        }
                    }
                    outR = new HTuple(tempOutR.ToArray());
                    outC = new HTuple(tempOutC.ToArray());
                }
                else
                {
                    hMetrologyModel.ApplyMetrologyModel(inImage);
                    outMeasureXLD = hMetrologyModel.GetMetrologyObjectMeasures("all", "all", out outR, out outC);
                }
                lineResult = hMetrologyModel.GetMetrologyObjectResult(new HTuple("all"), new HTuple("all"), new HTuple("result_type"), new HTuple("all_param"));
                if (lineResult.TupleLength() >= 4)
                {
                    outLine = new Rectangle_INFO(lineResult[0].D, lineResult[1].D, lineResult[2].D, lineResult[3].D);
                }
                else
                {
                    //if (fitLineByH(outR.ToDArr().ToList(), outC.ToDArr().ToList(), out outLine))
                     //   outLine = inLine;
                }

                hMetrologyModel.Dispose();
            }
            catch (Exception ex)
            {
                outLine = inLine;
                outR = new HTuple();
                outC = new HTuple();
                outMeasureXLD = new HXLDCont();
                hMetrologyModel.Dispose();
                Debug.Write(ex.Message);
            }
        }

        /// <summary>
        /// 检测矩形 增加屏蔽区域 magical20171028
        /// </summary>
        /// <param name="inImage">检测图像</param>
        /// <param name="inLine">输入检测直线区域</param>
        /// <param name="inMetrology">形态参数</param>
        /// <param name="outLine">输出直线</param>
        /// <param name="outR">输出行点</param>
        /// <param name="outC">输出列点</param>
        /// <param name="outMeasureXLD">输出检测轮廓</param>
        /// <param name="disableRegion">屏蔽区域 可选</param>
        /// <param name="isPaint">对屏蔽区域进行喷绘 可选</param>
        public static void MeasureRect2(HImage inImage, Rectangle2_INFO inRect2, Metrology_INFO inMetrology, out Rectangle2_INFO outRectangle2, out HTuple outR, out HTuple outC, out HXLDCont outMeasureXLD, HRegion disableRegion = null)
        {
            HMetrologyModel hMetrologyModel = new HMetrologyModel();
            try
            {
                outRectangle2 = new Rectangle2_INFO();
                HTuple Rectangle2Result = new HTuple();
                HTuple RectInfo = new HTuple();
                RectInfo.Append(new HTuple(new double[] { inRect2.CenterY, inRect2.CenterX, inRect2.Phi, inRect2.Length1, inRect2.Length2 }));
               // HTuple rad = new HTuple(90);
              //  rad= rad.TupleRad();
               // RectInfo.Append(new HTuple(new double[] { 599,279, rad, 62,51 }));

                //magical 20180405增加最强边的计算
                if (inMetrology.ParamValue[1] == "strongest")
                {
                    //MeasureLine1D(inImage, inLine, inMetrology, out outLine, out outR, out outC, out outMeasureXLD, disableRegion);
                   // return;
                }

                hMetrologyModel.AddMetrologyObjectGeneric(new HTuple("rectangle2"), RectInfo, new HTuple(inMetrology.Length1),
                    new HTuple(inMetrology.Length2), new HTuple(1), new HTuple(inMetrology.Threshold)
                    , inMetrology.ParamName, inMetrology.ParamValue);
                hMetrologyModel.SetMetrologyObjectParam(0, "min_score", 0.1);//降低直线拟合的最低得分,尽量使用halcon的拟合方法,因为VBA_Function.fitLine方法拟合的直线不准 magical 20171018


                if (disableRegion != null && disableRegion.IsInitialized())
                {
                    hMetrologyModel.ApplyMetrologyModel(inImage);

                    //单个测量区域 刚好 有一大半在屏蔽区域,一小部分在有效区域,这时候也会测出一个点,这个点在屏蔽区域内,导致精度损失约为1个像素左右.需要喷绘之后,再进行点是否在屏蔽区域判断
                    outMeasureXLD = hMetrologyModel.GetMetrologyObjectMeasures("all", "all", out outR, out outC);

                    List<double> tempOutR = new List<double>(), tempOutC = new List<double>();

                    for (int i = 0; i < outR.DArr.Length - 1; i++)
                    {
                        //0 表示没有包含
                        if (disableRegion.TestRegionPoint(outR[i].D, outC[i].D) == 0)
                        {
                            tempOutR.Add(outR[i].D);
                            tempOutC.Add(outC[i].D);
                        }
                    }
                    outR = new HTuple(tempOutR.ToArray());
                    outC = new HTuple(tempOutC.ToArray());
                }
                else
                {
                    hMetrologyModel.ApplyMetrologyModel(inImage);
                    outMeasureXLD = hMetrologyModel.GetMetrologyObjectMeasures("all", "all", out outR, out outC);
                }
                Rectangle2Result = hMetrologyModel.GetMetrologyObjectResult(new HTuple("all"), new HTuple("all"), new HTuple("result_type"), new HTuple("all_param"));
                if (Rectangle2Result.TupleLength() >= 5)
                {
                    outRectangle2 = new Rectangle2_INFO(Rectangle2Result[0].D, Rectangle2Result[1].D, Rectangle2Result[2].D, Rectangle2Result[3].D, Rectangle2Result[4].D);
                }
                else
                {
                    //if (fitLineByH(outR.ToDArr().ToList(), outC.ToDArr().ToList(), out outLine))
                    //   outLine = inLine;
                }

                hMetrologyModel.Dispose();
            }
            catch (Exception ex)
            {
                outRectangle2 = inRect2;
                outR = new HTuple();
                outC = new HTuple();
                outMeasureXLD = new HXLDCont();
                hMetrologyModel.Dispose();
                Debug.Write(ex.Message);
                Log.Error(ex.Message);
            }
        }

        /// <summary>
        /// /使用halcon的拟合直线算法,比fitLine更准确,因为有其自己的剔除异常点算法
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="line"></param>
        /// <returns>结果直线</returns>
        public static bool fitLineByH(List<Double> rows, List<Double> cols, out Line_INFO line)
        {
            line = new Line_INFO();
            try
            {
                SortPairs(ref rows, ref cols);
                double rowBegin, colBegin, rowEnd, colEnd, nr, nc, dist;
                HXLDCont lineXLD = new HXLDCont(new HTuple(rows.ToArray()), new HTuple(cols.ToArray()));
                lineXLD.FitLineContourXld("tukey", -1, 0, 5, 2, out rowBegin, out colBegin, out rowEnd, out colEnd, out nr, out nc, out dist);//tukey剔除算法为halcon推荐算法
                line = new Line_INFO(rowBegin, colBegin, rowEnd, colEnd);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        /// <summary>
        /// 点排序
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public static void SortPairs(ref List<double> rows, ref List<double> cols)
        {
            HTuple hv_T1 = new HTuple(rows.ToArray());
            HTuple hv_T2 = new HTuple(cols.ToArray());
            //相同的方法 直接使用htuple返回结果
            SortPairs(ref hv_T1, ref hv_T2);
            rows = hv_T1.ToDArr().ToList();
            cols = hv_T2.ToDArr().ToList();
            return;

            //HTuple hv_Sorted1 = new HTuple();
            //HTuple hv_Sorted2 = new HTuple();
            //HTuple hv_SortMode = new HTuple();
            //HTuple hv_Indices1 = new HTuple(), hv_Indices2 = new HTuple();
            //if ((rows.Max() - rows.Min()) > (cols.Max() - cols.Min()))
            //    hv_SortMode = new HTuple("1");
            //else
            //    hv_SortMode = new HTuple("2");
            //if ((int)((new HTuple(hv_SortMode.TupleEqual("1"))).TupleOr(new HTuple(hv_SortMode.TupleEqual(
            //    1)))) != 0)
            //{
            //    HOperatorSet.TupleSortIndex(hv_T1, out hv_Indices1);
            //    hv_Sorted1 = hv_T1.TupleSelect(hv_Indices1);
            //    hv_Sorted2 = hv_T2.TupleSelect(hv_Indices1);
            //}
            //else if ((int)((new HTuple((new HTuple(hv_SortMode.TupleEqual("column"))).TupleOr(
            //    new HTuple(hv_SortMode.TupleEqual("2"))))).TupleOr(new HTuple(hv_SortMode.TupleEqual(
            //    2)))) != 0)
            //{
            //    HOperatorSet.TupleSortIndex(hv_T2, out hv_Indices2);
            //    hv_Sorted1 = hv_T1.TupleSelect(hv_Indices2);
            //    hv_Sorted2 = hv_T2.TupleSelect(hv_Indices2);
            //}
            //rows = hv_Sorted1.ToDArr().ToList();
            //cols = hv_Sorted2.ToDArr().ToList();
        }
        /// <summary>
        /// 点排序
        /// </summary>
        /// <param name="hv_T1"></param>
        /// <param name="hv_T2"></param>
        public static void SortPairs(ref HTuple hv_T1, ref HTuple hv_T2)
        {
            HTuple hv_Sorted1 = new HTuple();
            HTuple hv_Sorted2 = new HTuple();
            HTuple hv_SortMode = new HTuple();
            HTuple hv_Indices1 = new HTuple(), hv_Indices2 = new HTuple();
            if ((hv_T1.TupleMax().D - hv_T1.TupleMin().D) > (hv_T2.TupleMax().D - hv_T2.TupleMin().D))
                hv_SortMode = new HTuple("1");
            else
                hv_SortMode = new HTuple("2");
            if ((int)((new HTuple(hv_SortMode.TupleEqual("1"))).TupleOr(new HTuple(hv_SortMode.TupleEqual(
                1)))) != 0)
            {
                HOperatorSet.TupleSortIndex(hv_T1, out hv_Indices1);
                hv_Sorted1 = hv_T1.TupleSelect(hv_Indices1);
                hv_Sorted2 = hv_T2.TupleSelect(hv_Indices1);
            }
            else if ((int)((new HTuple((new HTuple(hv_SortMode.TupleEqual("column"))).TupleOr(
                new HTuple(hv_SortMode.TupleEqual("2"))))).TupleOr(new HTuple(hv_SortMode.TupleEqual(
                2)))) != 0)
            {
                HOperatorSet.TupleSortIndex(hv_T2, out hv_Indices2);
                hv_Sorted1 = hv_T1.TupleSelect(hv_Indices2);
                hv_Sorted2 = hv_T2.TupleSelect(hv_Indices2);
            }
            hv_T1 = hv_Sorted1;
            hv_T2 = hv_Sorted2;
        }

        /// <summary>
        /// 利用一维测量算子,检测直线.再利用halcon的拟合直线算法拟合直线 主要用于最强边缘的测量 magical20180405
        /// </summary>
        /// <param name="inImage"></param>
        /// <param name="inLine"></param>
        /// <param name="inMetrology"></param>
        /// <param name="outLine"></param>
        /// <param name="outR"></param>
        /// <param name="outC"></param>
        /// <param name="outMeasureXLD"></param>
        /// <param name="disableRegion"></param>
        /// <param name="isPaint"></param>
        public static void MeasureLine1D(HImage inImage, Line_INFO inLine, Metrology_INFO inMetrology, out Line_INFO outLine, out HTuple outR, out HTuple outC, out HXLDCont outMeasureXLD, HRegion disableRegion = null, bool isPaint = true)
        {

            outLine = inLine;
            outR = new HTuple();
            outC = new HTuple();
            List<double> outRList = new List<double>();
            List<double> outCList = new List<double>();
            HImage tempImage;
            if (disableRegion != null && disableRegion.IsInitialized())
            {
                //将屏蔽区域喷绘为0,这样就无法测量到点 magical 20171028
                tempImage = disableRegion.PaintRegion(inImage, 0d, "fill");
            }
            else
            {
                tempImage = inImage;
            }

            //注意下这里的角度
            double angle = HMisc.AngleLx(inLine.StartY, inLine.StartX, inLine.EndY, inLine.EndX);
            int pointsNum = (int)((HMisc.DistancePp(inLine.StartY, inLine.StartX, inLine.EndY, inLine.EndX) - 2 * inMetrology.Length2) / inMetrology.MeasureDis) + 1;
            double newMeasureDis = (HMisc.DistancePp(inLine.StartY, inLine.StartX, inLine.EndY, inLine.EndX) - 2 * inMetrology.Length2) / pointsNum;
            double rectRowC, rectColC;

            outMeasureXLD = new HXLDCont();
            outMeasureXLD.GenEmptyObj();
            for (int i = 0; i <= pointsNum; i++)
            {
                //rectRowC = inLine.StartY + (((inLine.EndY - inLine.StartY) * (i + 1)) / (pointsNum)) + inMetrology.Length2*Math.Sin(angle);
                //rectColC = inLine.StartX + (((inLine.EndX - inLine.StartX) * (i )) / (pointsNum))+ inMetrology.Length2 * Math.Cos(angle);
                rectRowC = inLine.StartY + (inMetrology.Length2 - i * newMeasureDis) * Math.Sin(angle);
                rectColC = inLine.StartX + (inMetrology.Length2 + i * newMeasureDis) * Math.Cos(angle);



                HXLDCont tempRect = new HXLDCont();
                tempRect.GenRectangle2ContourXld(rectRowC, rectColC, angle - Math.PI / 2, inMetrology.Length1, inMetrology.Length2);
                outMeasureXLD = outMeasureXLD.ConcatObj(tempRect);


                HMeasure mea = new HMeasure();
                int width, height;
                inImage.GetImageSize(out width, out height);
                mea.GenMeasureRectangle2(rectRowC, rectColC, angle - Math.PI / 2, inMetrology.Length1, inMetrology.Length2, width, height, "nearest_neighbor");
                HTuple rowEdge, columnEdge, amplitude, distance;
                mea.MeasurePos(tempImage, 1, inMetrology.Threshold, inMetrology.ParamValue[0], "all", out rowEdge, out columnEdge, out amplitude, out distance);

                if (amplitude != null & amplitude.Length > 0)
                {
                    // amplitude.TupleSort();
                    HTuple HIndex = amplitude.TupleAbs().TupleSortIndex();
                    outRList.Add(rowEdge[HIndex[HIndex.Length - 1].I]);
                    outCList.Add(columnEdge[HIndex[HIndex.Length - 1].I]);
                }

                mea.Dispose();
            }
            outR = new HTuple(outRList.ToArray());
            outC = new HTuple(outCList.ToArray());

            if (disableRegion != null && disableRegion.IsInitialized())
            {
                List<double> tempOutR = new List<double>(), tempOutC = new List<double>();
                for (int i = 0; i < outR.DArr.Length - 1; i++)
                {
                    //0 表示没有包含
                    if (disableRegion.TestRegionPoint(outR[i].D, outC[i].D) == 0)
                    {
                        tempOutR.Add(outR[i].D);
                        tempOutC.Add(outC[i].D);
                    }
                }
                outR = new HTuple(tempOutR.ToArray());
                outC = new HTuple(tempOutC.ToArray());
            }

            if (outR.Length > 0)
            {
                fitLineByH(outRList, outCList, out outLine);
            }
            else
            {
                outLine = inLine;
            }

        }
        /// <summary>
        /// 计算rms误差
        /// </summary>
        /// <param name="hom2d"></param>
        /// <param name="x_Image"></param>
        /// <param name="y_Image"></param>
        /// <param name="x_Robot"></param>
        /// <param name="y_Robot"></param>
        /// <returns></returns>
        public  double CalculateRMS(HHomMat2D hom2d, HTuple x_Image, HTuple y_Image, HTuple x_Robot, HTuple y_Robot)
        {
            try
            {
                double count = 0;
                for (int i = 0; i < x_Image.Length; i++)
                {
                    double tempX, tempY;
                    tempX = hom2d.HomMat2dInvert().AffineTransPoint2d(x_Robot[i].D, y_Robot[i].D, out tempY);

                    double dis = HMisc.DistancePp(tempY, tempX, y_Image[i], x_Image[i]);
                    count = count + dis * dis;
                }
                double RMS = Math.Sqrt(count / x_Image.Length);
                return RMS;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        /// <summary>
        /// 检测圆
        /// </summary>
        /// <param name="inImage">输入图像</param>
        /// <param name="inCircle">输入圆</param>
        /// <param name="inMetrology">输入形态学</param>
        /// <param name="outCircle">输出圆</param>
        /// <param name="outR">输出行坐标</param>
        /// <param name="outC">输出列坐标</param>
        /// <param name="outMeasureXLD">输出检测轮廓</param>
        public static void MeasureCircle(HImage inImage, Circle_INFO inCircle, Metrology_INFO inMetrology, HRegion disableRegion, out Circle_INFO outCircle, out HTuple outR, out HTuple outC, out HXLDCont outMeasureXLD)
        {
            HMetrologyModel hMetrologyModel = new HMetrologyModel();

            try
            {
                outCircle = new Circle_INFO();
                HTuple CircleResult = new HTuple();
                HTuple CircleInfo = new HTuple();
                CircleInfo.Append(new HTuple(new double[] { inCircle.CenterY, inCircle.CenterX, inCircle.Radius }));
                hMetrologyModel.AddMetrologyObjectGeneric(new HTuple("circle"), CircleInfo, new HTuple(inMetrology.Length1),
                    new HTuple(inMetrology.Length2), new HTuple(1), new HTuple(inMetrology.Threshold)
                    , inMetrology.ParamName, inMetrology.ParamValue);

                hMetrologyModel.ApplyMetrologyModel(inImage);
                outMeasureXLD = hMetrologyModel.GetMetrologyObjectMeasures("all", "all", out outR, out outC);

                if (disableRegion != null && disableRegion.IsInitialized() && disableRegion.Area > 0 && outR.Length > 0)
                {
                    List<double> tempOutR = new List<double>(), tempOutC = new List<double>();
                    for (int i = 0; i < outR.DArr.Length - 1; i++)
                    {
                        //0 表示没有包含
                        if (disableRegion.TestRegionPoint(outR[i].D, outC[i].D) == 0)
                        {
                            tempOutR.Add(outR[i].D);
                            tempOutC.Add(outC[i].D);
                        }
                    }
                    outR = new HTuple(tempOutR.ToArray());
                    outC = new HTuple(tempOutC.ToArray());
                    fitCircle(outR.ToDArr().ToList(), outC.ToDArr().ToList(), out outCircle);
                    //outMeasureXLD = outCircle.genXLD();
                }
                else
                {
                    CircleResult = hMetrologyModel.GetMetrologyObjectResult(new HTuple("all"), new HTuple("all"), new HTuple("result_type"), new HTuple("all_param"));
                    if (CircleResult.TupleLength() >= 3)
                    {
                        outCircle.CenterY = CircleResult[0].D;
                        outCircle.CenterX = CircleResult[1].D;
                        outCircle.Radius = CircleResult[2].D;
                    }
                    else
                    {
                        fitCircle(outR.ToDArr().ToList(), outC.ToDArr().ToList(), out outCircle);
                    }
                }



                hMetrologyModel.Dispose();
            }
            catch (Exception ex)
            {
                outCircle = inCircle;
                outR = new HTuple();
                outC = new HTuple();
                outMeasureXLD = new HXLDCont();
                hMetrologyModel.Dispose();
                Debug.Write(ex.Message);
            }
        }

        /// <summary>
        /// 最小二乘法圆拟合
        /// </summary>
        /// <param name="rows">点云 行坐标</param>
        /// <param name="cols">点云 列坐标</param>
        /// <param name="circle">返回圆</param>
        /// <returns>是否拟合成功</returns>
        public static bool fitCircle(List<Double> rows, List<Double> cols, out Circle_INFO circle)
        {
            circle = new Circle_INFO();
            if (cols.Count < 3)
            {
                return false;
            }
            //HTuple resultTuple;
            //if (Wrapper.Fun.fitCircle(new HTuple(rows.ToArray()), new HTuple(cols.ToArray()), out resultTuple))
            //{
            //    circle.CenterY = resultTuple[1];
            //    circle.CenterX = resultTuple[0];
            //    circle.Radius = resultTuple[2];
            //    return true;
            //}
            //return false;

            //本地代码验证通过------20180827 yoga
            ////原始托管代码
            double sum_x = 0.0f, sum_y = 0.0f;
            double sum_x2 = 0.0f, sum_y2 = 0.0f;
            double sum_x3 = 0.0f, sum_y3 = 0.0f;
            double sum_xy = 0.0f, sum_x1y2 = 0.0f, sum_x2y1 = 0.0f;

            int N = cols.Count;
            for (int i = 0; i < N; i++)
            {
                double x = rows[i];
                double y = cols[i];
                double x2 = x * x;
                double y2 = y * y;
                sum_x += x;
                sum_y += y;
                sum_x2 += x2;
                sum_y2 += y2;
                sum_x3 += x2 * x;
                sum_y3 += y2 * y;
                sum_xy += x * y;
                sum_x1y2 += x * y2;
                sum_x2y1 += x2 * y;
            }

            double C, D, E, G, H;
            double a, b, c;

            C = N * sum_x2 - sum_x * sum_x;
            D = N * sum_xy - sum_x * sum_y;
            E = N * sum_x3 + N * sum_x1y2 - (sum_x2 + sum_y2) * sum_x;
            G = N * sum_y2 - sum_y * sum_y;
            H = N * sum_x2y1 + N * sum_y3 - (sum_x2 + sum_y2) * sum_y;
            a = (H * D - E * G) / (C * G - D * D);
            b = (H * C - E * D) / (D * D - G * C);
            c = -(a * sum_x + b * sum_y + sum_x2 + sum_y2) / N;

            circle.CenterY = a / (-2);
            circle.CenterX = b / (-2);
            circle.Radius = Math.Sqrt(a * a + b * b - 4 * c) / 2;
            return true;
        }
        /// <summary>
        /// 检测椭圆
        /// </summary>
        /// <param name="inImage">输入图像</param>
        /// <param name="inEllipse">输入椭圆</param>
        /// <param name="inMetrology">输入形态学</param>
        /// <param name="outEllipse">输出椭圆</param>
        /// <param name="outR">输出行坐标</param>
        /// <param name="outC">输出列坐标</param>
        /// <param name="outMeasureXLD">输出检测轮廓</param>
        public static void MeasureEllipse(HImage inImage, Ellipse_INFO inEllipse, Metrology_INFO inMetrology, out Ellipse_INFO outEllipse, out HTuple outR, out HTuple outC, out HXLDCont outMeasureXLD)
        {
            HMetrologyModel hMetrologyModel = new HMetrologyModel();

            try
            {
                outEllipse = new Ellipse_INFO();
                HTuple EllipseResult = new HTuple();
                HTuple EllipseInfo = new HTuple();
                EllipseInfo.Append(new HTuple(new double[] { inEllipse.CenterY, inEllipse.CenterX, inEllipse.Phi, inEllipse.Radius1, inEllipse.Radius2 }));
                //hMetrologyModel.AddMetrologyObjectGeneric(new HTuple("ellipse"), EllipseInfo, new HTuple(inMetrology.Length1),
                //    new HTuple(inMetrology.Length2), new HTuple(1), new HTuple(inMetrology.Threshold)
                //    , inMetrology.ParamName, inMetrology.ParamValue);
                hMetrologyModel.AddMetrologyObjectEllipseMeasure(new HTuple(inEllipse.CenterY), new HTuple(inEllipse.CenterX), new HTuple(inEllipse.Phi),
                    new HTuple(inEllipse.Radius1), new HTuple(inEllipse.Radius2), new HTuple(inMetrology.Length1),
                    new HTuple(inMetrology.Length2), new HTuple(1), new HTuple(inMetrology.Threshold), inMetrology.ParamName, inMetrology.ParamValue);
                hMetrologyModel.SetMetrologyObjectParam("all", "max_num_iterations", 70);
                hMetrologyModel.ApplyMetrologyModel(inImage);
                outMeasureXLD = hMetrologyModel.GetMetrologyObjectMeasures("all", "all", out outR, out outC);

                EllipseResult = hMetrologyModel.GetMetrologyObjectResult(new HTuple("all"), new HTuple("all"), new HTuple("result_type"), new HTuple("all_param"));
                if (EllipseResult.TupleLength() >= 4)
                {
                    outEllipse.CenterY = EllipseResult[0].D;
                    outEllipse.CenterX = EllipseResult[1].D;
                    outEllipse.Phi = EllipseResult[2].D;
                    outEllipse.Radius1 = EllipseResult[3].D;
                    outEllipse.Radius2 = EllipseResult[4].D;
                }

                hMetrologyModel.Dispose();
            }
            catch (Exception ex)
            {
                outEllipse = inEllipse;
                outR = new HTuple();
                outC = new HTuple();
                outMeasureXLD = new HXLDCont();
                hMetrologyModel.Dispose();
                Debug.Write(ex.Message);
            }
        }
        /// <summary>
        /// 边缘对检测
        /// </summary>
        /// <param name="inImage">输入图像</param>
        /// <param name="inCross">输入矩形框中心</param>
        /// <param name="inMetrology">形态学参数</param>
        /// <param name="lstLine">返回直线列表</param>
        /// <param name="lstWidth">直线长度</param>
        /// <param name="lstDistance">直线间隔</param>
        /// <param name="outMeasureXLD">直线轮廓</param>
        public static void MeasurePairs(HImage inImage, Coordinate_INFO inCross, Metrology_INFO inMetrology, out List<Line_INFO> lstLine, out List<double> lstWidth, out List<double> lstDistance, out HXLDCont outMeasureXLD)
        {
            HMeasure hMeasure = new HMeasure();
            lstLine = new List<Line_INFO>();
            lstWidth = new List<double>();
            lstDistance = new List<double>();
            outMeasureXLD = new HXLDCont();
            outMeasureXLD.GenEmptyObj();
            try
            {
                HTuple rowEdgeFirst = new HTuple();
                HTuple columnEdgeFirst = new HTuple();
                HTuple amplitudeFirst = new HTuple();
                HTuple rowEdgeSecond = new HTuple();
                HTuple columnEdgeSecond = new HTuple();
                HTuple amplitudeSecond = new HTuple();
                HTuple intraDistance = new HTuple();
                HTuple interDistance = new HTuple();
                string tempStr = "all_strongest";
                if (inMetrology.ParamValue[0].S == "negative")
                {
                    tempStr = "negative_strongest";
                }
                else if (inMetrology.ParamValue[0].S == "positive")
                {
                    tempStr = "positive_strongest";
                }
                else if (inMetrology.ParamValue[0].S == "uniform")
                {
                    tempStr = "all_strongest";
                }
                int width, height;
                inImage.GetImageSize(out width, out height);
                hMeasure.GenMeasureRectangle2(inCross.Y, inCross.X, inCross.Phi, inMetrology.Length1, inMetrology.Length2, width, height, "nearest_neighbor");
                hMeasure.MeasurePairs(inImage, 1.5, inMetrology.Threshold, tempStr, inMetrology.ParamValue[1].S,
                    out rowEdgeFirst, out columnEdgeFirst, out amplitudeFirst, out rowEdgeSecond, out columnEdgeSecond, out amplitudeSecond, out intraDistance, out interDistance);

                if (rowEdgeFirst.Length > 0)
                {
                    for (int i = 0; i < rowEdgeFirst.Length; i++)
                    {
                        Line_INFO temp = new Line_INFO(rowEdgeFirst[i].D, columnEdgeFirst[i].D, rowEdgeSecond[i].D, columnEdgeSecond[i].D);
                        lstLine.Add(temp);
                        HXLDCont xld = new HXLDCont();
                        HTuple row = (new HTuple(rowEdgeFirst[i].D)).TupleConcat(rowEdgeSecond[i].D);
                        HTuple col = (new HTuple(columnEdgeFirst[i].D)).TupleConcat(columnEdgeSecond[i].D);
                        xld.GenContourPolygonXld(row, col);
                        outMeasureXLD = outMeasureXLD.ConcatObj(xld);
                    }
                    lstWidth = intraDistance.ToDArr().ToList();
                    lstDistance = interDistance.ToDArr().ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                hMeasure.Dispose();
            }
        }
        /// <summary>
        /// 根据坐标重定位矩阵的位置
        /// </summary>
        /// <param name="inRectangleList">输入原始矩阵</param>
        /// <param name="inCoordInfo">坐标系</param>
        /// <param name="outRectangleList">输出像素矩阵</param>
        public static void RectPosition(HImageExt img, List<Rectangle2_INFO> inRectangleList, Coordinate_INFO inCoordInfo, out List<Rectangle2_INFO> outRectangleList)
        {
            try
            {
                outRectangleList = new List<Rectangle2_INFO>();
                HHomMat2D homMat2D = new HHomMat2D();
                homMat2D = homMat2D.HomMat2dRotateLocal(inCoordInfo.Phi);
                homMat2D = homMat2D.HomMat2dTranslate(inCoordInfo.X, inCoordInfo.Y);
                foreach (Rectangle2_INFO r in inRectangleList)
                {
                    double x, y, row, col;
                    x = homMat2D.AffineTransPoint2d(r.CenterX, r.CenterY, out y);
                    HMeasureSet.WorldPlane2Point(img, x, y, out row, out col);
                    Rectangle2_INFO temp_R = new Rectangle2_INFO();
                    temp_R.CenterY = row;
                    temp_R.CenterX = col;
                    temp_R.Phi = r.Phi + inCoordInfo.Phi;
                    //temp_R.Length1 = r.Length1 / (img.ScaleX + img.ScaleY) / 2;
                    //temp_R.Length2 = r.Length2 / (img.ScaleX + img.ScaleY) / 2;
                    //此处错误  应该是行列的比例整体除以2  yoga 20180827
                    temp_R.Length1 = r.Length1 / ((img.ScaleX + img.ScaleY) / 2);
                    temp_R.Length2 = r.Length2 / ((img.ScaleX + img.ScaleY) / 2);

                    outRectangleList.Add(temp_R);
                }
            }
            catch (System.Exception ex)
            {
                outRectangleList = new List<Rectangle2_INFO>();
                Debug.Write(ex.Message);
            }

        }
        /// <summary>
        /// 获取矩形框的值
        /// </summary>
        /// <param name="inImage">输入图像</param>
        /// <param name="inRectangleList">矩形阵列</param>
        /// <param name="inPreTreatMent">预处理</param>
        /// <param name="outRectInfo">返回RectInfo列表</param>
        public static void QueryRectInfo(HImageExt inImage, List<Rectangle2_INFO> inRectangleList, PreTreatMent inPreTreatMent, out List<RectInfo> outRectInfo)
        {
            try
            {
                outRectInfo = new List<RectInfo>();
                HRegion m_Region = new HRegion();
                var rowList = from datacell in inRectangleList select datacell.CenterY;
                var colList = from datacell in inRectangleList select datacell.CenterX;
                var phiList = from datacell in inRectangleList select datacell.Phi;
                var length1List = from datacell in inRectangleList select datacell.Length1;
                var length2List = from datacell in inRectangleList select datacell.Length2;

                m_Region.GenRectangle2(new HTuple(rowList.ToArray()), new HTuple(colList.ToArray()), new HTuple(phiList.ToArray()),
                    new HTuple(length1List.ToArray()), new HTuple(length2List.ToArray()));

                HTuple rows, cols, temp_values;
                int count = m_Region.CountObj();
                if (inPreTreatMent == PreTreatMent.无)
                {

                }
                else if (inPreTreatMent == PreTreatMent.均值滤波)
                {
                    inImage = HImageExt.Instance(inImage.MeanImage(3, 3));
                }
                else if (inPreTreatMent == PreTreatMent.中值滤波)
                {
                    inImage = HImageExt.Instance(inImage.MedianImage("circle", 1, "mirrored"));
                }
                else if (inPreTreatMent == PreTreatMent.高斯滤波)
                {
                    inImage = HImageExt.Instance(inImage.GaussFilter(3));
                }
                else if (inPreTreatMent == PreTreatMent.平滑滤波)
                {
                    inImage = HImageExt.Instance(inImage.SmoothImage("deriche2", 0.5));
                }
                for (int i = 0; i < count; i++)
                {
                    RectInfo _RectInfo = new RectInfo();
                    m_Region[i + 1].GetRegionPoints(out rows, out cols);
                    temp_values = inImage.GetGrayval(rows, cols);
                    _RectInfo.X = inRectangleList[i].CenterX * inImage.ScaleX;
                    _RectInfo.Y = inRectangleList[i].CenterY * inImage.ScaleY;
                    _RectInfo.Value_Avg = temp_values.TupleMean().D;
                    _RectInfo.Value_Median = temp_values.TupleMedian().D;
                    _RectInfo.Value_Max = temp_values.TupleMax().D;
                    _RectInfo.Value_Min = temp_values.TupleMin().D;
                    _RectInfo.X_List = cols.TupleMult(inImage.ScaleX).ToDArr().ToList();
                    _RectInfo.Y_List = rows.TupleMult(inImage.ScaleY).ToDArr().ToList();
                    _RectInfo.Value_List = temp_values.ToDArr().ToList();

                    outRectInfo.Add(_RectInfo);
                }
                m_Region.Dispose();

            }
            catch (System.Exception ex)
            {
                outRectInfo = new List<RectInfo>();
                Debug.Write(ex.Message);
            }
        }
        /// <summary>
        /// 查询图片
        /// </summary>
        /// <param name="m_ImageCatagory">图片类型</param>
        /// <param name="m_CurrentImgName">当前图片名称</param>
        /// <param name="m_RegisterImgName">注册图名称</param>
        /// <param name="m_Image">返回图像</param>
        //  public static void QueryImage(List<F_CELL_DATA> VariableList, List<RegisterIMG_Info> m_RegisterImg, ImageCatagory m_ImageCatagory, string ImgName, out HImageExt m_Image)
        public static void QueryImage(List<F_CELL_DATA> VariableList, ImageCatagory m_ImageCatagory, string ImgName, out HImageExt m_Image)
        {
            try
            {
                m_Image = new HImageExt();
                if (m_ImageCatagory == ImageCatagory.当前图像)
                {
                    F_CELL_DATA datacell = VariableList.FirstOrDefault(c => c.m_Data_Name == ImgName);
                    if (datacell.m_Data_Value != null)
                    {
                        m_Image = ((List<HImageExt>)datacell.m_Data_Value)[0];
                    }
                }
                //else if (m_ImageCatagory == ImageCatagory.注册图像)
                //{
                //    RegisterIMG_Info datacell = m_RegisterImg.FirstOrDefault(c => c.m_ImageID == ImgName);
                //    if (datacell.m_Image.IsInitialized())
                //    {
                //        m_Image = datacell.m_Image;
                //    }
                //}
            }
            catch (System.Exception ex)
            {
                m_Image = new HImageExt();
                Debug.Write(ex.Message);
            }

        }
        /// <summary>
        /// 创建模板
        /// </summary>
        /// <param name="_Type">模板类型</param>
        /// <param name="_Model">模板</param>
        /// <param name="_image">图像</param>
        /// <param name="_region">模板区域</param>
        public static void CreateModel(ModelType _Type, ref HHandle _Model, double _StartPhi, double _EndPhi, HImage _image, UserDefine.ROI _roi)
        {
            try
            {
                if (_image.IsInitialized())
                {
                    HRegion _region = _roi.genRegion();
                    if (_region.IsInitialized())
                    {
                        _image = _image.ReduceDomain(_region);
                        //_image = _image.MeanImage(5, 5);
                    }
                    if (_Type == ModelType.形状模板)
                    {
                        HXLDCont xld = _image.EdgesSubPix("canny", 1, 20, 40);
                        //                     HTuple tLength = xld.LengthXld();
                        //                     double _max = tLength.TupleMax();
                        //                     xld = xld.SelectContoursXld("contour_length", _max, _max + 1, -0.5, 0.5);
                        //((HShapeModel)_Model).CreateShapeModelXld(xld, "auto", -0.39, 0.78, "auto", "auto", "ignore_local_polarity", 5);
                        ((HShapeModel)_Model).CreateScaledShapeModelXld(xld, "auto", Math.Round(_StartPhi * Math.PI / 180, 3), Math.Round((_EndPhi - _StartPhi) * Math.PI / 180, 3), "auto", 0.9, 1.1, "auto", "auto", "use_polarity", 5);
                        xld.Dispose();
                    }
                    else if (_Type == ModelType.灰度模板)
                    {
                        ((HNCCModel)_Model).CreateNccModel(_image, "auto", Math.Round(_StartPhi * Math.PI / 180, 3), Math.Round((_EndPhi - _StartPhi) * Math.PI / 180, 3), "auto", "use_polarity");
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        /// <summary>
        /// 查找最佳模板
        /// </summary>
        /// <param name="_Type">模板类型</param>
        /// <param name="_Model">模式</param>
        /// <param name="_image">图片</param>
        /// <param name="_region">寻找区域</param>
        /// <param name="outCoord">输出坐标</param>
        public static int FindModel(ModelType _Type, HHandle _Model, double _StartPhi, double _EndPhi, HImage _image, UserDefine.ROI _roi, out Coordinate_INFO outCoord)
        {
            int num = 0;
            outCoord = new Coordinate_INFO();
            try
            {
                HTuple row, col, Phi, scale, score;
                if (_image.IsInitialized())
                {
                    HRegion _region = _roi.genRegion();
                    if (_region.IsInitialized())
                    {
                        _image = _image.ReduceDomain(_region);
                    }
                    if (_Type == ModelType.形状模板)
                    {
                        ((HShapeModel)_Model).FindScaledShapeModel(_image, Math.Round(_StartPhi * Math.PI / 180, 3), Math.Round((_EndPhi - _StartPhi) * Math.PI / 180, 3), 0.9, 1.1, 0.5, 1, 0.5, "least_squares", 0, 0.9, out row, out col, out Phi, out scale, out score);
                        if (score.Length > 0)
                        {
                            outCoord.Y = row[0].D;
                            outCoord.X = col[0].D;
                            outCoord.Phi = Phi[0].D;
                        }
                        num = score.Length;
                    }
                    else if (_Type == ModelType.灰度模板)
                    {
                        ((HNCCModel)_Model).FindNccModel(_image, Math.Round(_StartPhi * Math.PI / 180, 3), Math.Round((_EndPhi - _StartPhi) * Math.PI / 180, 3), 0.8, 1, 0.5, "true", 0, out row, out col, out Phi, out score);
                        if (score.Length > 0)
                        {
                            outCoord.Y = row[0].D;
                            outCoord.X = col[0].D;
                            outCoord.Phi = Phi[0].D;
                        }
                        num = score.Length;
                    }
                    
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return num;

        }
        /// <summary>
        /// 查找模板多个
        /// </summary>
        /// <param name="_image">图片</param>
        /// <param name="_StartPhi">起始角度</param>
        /// <param name="_EndPhi">结束角度</param>
        /// <param name="_ScaleMin">最小缩放比率</param>
        /// <param name="_ScaleMax">最大缩放比率</param>
        /// <param name="_MinScore">最小分数</param>
        /// <param name="_NumMatch">匹配数量</param>
        /// <param name="_MaxOverlap">最大重叠</param>
        /// <param name="_SubPixel">亚像素</param>
        /// <param name="_NumLevels">金字塔等级</param>
        /// <param name="_Greediness">贪心算法</param>
        /// <param name="_Type">模板类型</param>
        /// <param name="_Model">模式</param>
        /// <param name="_roi">寻找区域</param>
        /// <param name="outCoord">输出坐标</param>
        public static void FindModel(HImage _image, double _StartPhi, double _EndPhi, double _ScaleMin, double _ScaleMax, double _MinScore, int _NumMatch,
            double _MaxOverlap, string _SubPixel, int _NumLevels, double _Greediness, ModelType _Type, HHandle _Model, UserDefine.ROI _roi, out Coordinate_INFO[] outCoord)
        {
            outCoord = new Coordinate_INFO[1];
            try
            {
                HTuple row, col, Phi, scale, score;
                if (_image.IsInitialized())
                {
                    HRegion _region = _roi.genRegion();
                    if (_region.IsInitialized())
                    {
                        _image = _image.ReduceDomain(_region);
                    }
                    if (_Type == ModelType.形状模板)
                    {
                        HShapeModel[] mod = new HShapeModel[1];
                        mod[0] = (HShapeModel)_Model;
                        ((HShapeModel)_Model).FindScaledShapeModel(
                            _image, //模板                           
                            Math.Round(_StartPhi * Math.PI / 180, 3),//起始角度
                            Math.Round((_EndPhi - _StartPhi) * Math.PI / 180, 3),//角度范围
                            _ScaleMin,//最小缩放倍率
                            _ScaleMax,//最大缩放倍率
                            _MinScore, //最小分数
                            _NumMatch, //匹配个数
                            _MaxOverlap,//最大重叠
                            _SubPixel, //亚像素模式
                            _NumLevels,//金字塔等级
                            _Greediness, //贪心算法
                            out row, out col, out Phi, out scale, out score);
                        if (score.Length > 0)
                        {
                            outCoord = new Coordinate_INFO[score.Length];
                            for (int i = 0; i < score.Length; i++)
                            {
                                outCoord[i].Y = row[i].D;
                                outCoord[i].X = col[i].D;
                                outCoord[i].Phi = Phi[i].D;
                            }

                        }
                        else
                        {
                            outCoord[0].Y = 1;
                            outCoord[0].X = 1;
                            outCoord[0].Phi = 1;
                        }
                    }
                    else if (_Type == ModelType.灰度模板)
                    {
                        ((HNCCModel)_Model).FindNccModel(_image, Math.Round(_StartPhi * Math.PI / 180, 3), Math.Round((_EndPhi - _StartPhi) * Math.PI / 180, 3), 0.8, 1, 0.5, "true", 0, out row, out col, out Phi, out score);
                        if (score.Length > 0)
                        {
                            outCoord = new Coordinate_INFO[score.Length];
                            for (int i = 0; i < score.Length; i++)
                            {
                                outCoord[i].Y = row[i].D;
                                outCoord[i].X = col[i].D;
                                outCoord[i].Phi = Phi[i].D;
                            }
                        }
                        else
                        {
                            outCoord[0].Y = 1;
                            outCoord[0].X = 1;
                            outCoord[0].Phi = 1;
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        /// <summary>
        /// 查找模板
        /// </summary>
        /// <param name="_Type">模板类型</param>
        /// <param name="_Model">模式</param>
        /// <param name="_image">图片</param>
        /// <param name="_region">寻找区域</param>
        /// <param name="outCoord">输出坐标</param>
        // HMeasureSet.FindModels(m_Image, m_StartPhi, m_EndPhi, m_ScaleMin, m_ScaleMax, m_MinScore, m_NumMatch,
        //   m_MaxOverlap, m_SubPixel, m_NumLevels, m_Greediness, m_ModelType, m_Model, m_SearchRegion, out coord);
        public static void FindModels(HImage _image, double _StartPhi, double _EndPhi, double ScaleMin, double ScaleMax,
            double MinScore, int NumMatches, double MaxOverlap, string SubPixel, int NumLevels, double Greediness, ModelType _Type,
            HHandle _Model, UserDefine.ROI _roi, out Coordinate_INFO[] outCoord)
        {
            outCoord = new Coordinate_INFO[1];
            // double ScaleMax = 1;//最大比例
            // double ScaleMin = 0.9;//最小比例
            // double MinScore = 0.5;//最小分数
            // int NumMatches = 50;//查询个数
            // double MaxOverlap = 0.5;//覆盖比例
            // int NumLevels = 2;//金子塔模型层数
            try
            {
                HTuple row, col, Phi, scale, score, Model_index;
                if (_image.IsInitialized())
                {
                    HRegion _region = _roi.genRegion();

                    if (_region.IsInitialized())
                    {
                        _image = _image.ReduceDomain(_region);
                    }
                    if (_Type == ModelType.形状模板)
                    {
                        HShapeModel[] mod = new HShapeModel[1];
                        mod[0] = (HShapeModel)_Model;
                        ((HShapeModel)_Model).FindScaledShapeModels(_image, Math.Round(_StartPhi * Math.PI / 180, 3), Math.Round((_EndPhi - _StartPhi) * Math.PI / 180, 3),
                            ScaleMin, ScaleMax, MinScore, NumMatches, MaxOverlap, SubPixel, NumLevels, Greediness, out row, out col, out Phi, out scale, out score, out Model_index);
                        if (score.Length > 0)
                        {
                            outCoord = new Coordinate_INFO[score.Length];
                            for (int i = 0; i < score.Length; i++)
                            {
                                outCoord[i].Y = row[i].D;
                                outCoord[i].X = col[i].D;
                                outCoord[i].Phi = Phi[i].D;
                            }
                        }
                    }

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        /// <summary>
        /// 根据位置变换矩形
        /// </summary>
        /// <param name="homMat">变换关系</param>
        /// <param name="rect">矩阵</param>
        public static Rectangle2_INFO AffineRectangle2(HHomMat2D homMat, Rectangle2_INFO rect)
        {
            Rectangle2_INFO outRect = new Rectangle2_INFO();
            double row, col, Phi;
            row = homMat.AffineTransPoint2d(rect.CenterY, rect.CenterX, out col);
            Phi = ((HTuple)homMat[0]).TupleAcos().D;
            outRect.Length1 = rect.Length1;
            outRect.Length2 = rect.Length2;
            outRect.CenterY = row;
            outRect.CenterX = col;
            outRect.Phi = rect.Phi + Phi;
            return outRect;
        }
        /// <summary>
        /// 创建箭头xld
        /// </summary>
        /// <param name="ho_Arrow">返回箭头轮廓</param>
        /// <param name="hv_Row1">起始点row</param>
        /// <param name="hv_Column1">起始点col</param>
        /// <param name="hv_Row2">终点row</param>
        /// <param name="hv_Column2">终点col</param>
        /// <param name="hv_HeadLength">箭头长度</param>
        /// <param name="hv_HeadWidth">箭头宽度</param>
        public static void GenArrowContourXld(out HXLDCont ho_Arrow, HTuple hv_Row1, HTuple hv_Column1,
            HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
        {

            HTuple hv_Length = null, hv_ZeroLengthIndices = null;
            HTuple hv_DR = null, hv_DC = null, hv_HalfHeadWidth = null;
            HTuple hv_RowP1 = null, hv_ColP1 = null, hv_RowP2 = null;
            HTuple hv_ColP2 = null, hv_Index = null;
            // Initialize local and output iconic variables 
            ho_Arrow = new HXLDCont();
            HXLDCont ho_TempArrow = new HXLDCont();

            HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
            //
            //Mark arrows with identical start and end point
            //(set Length to -1 to avoid division-by-zero exception)
            hv_ZeroLengthIndices = hv_Length.TupleFind(0);
            if ((int)(new HTuple(hv_ZeroLengthIndices.TupleNotEqual(-1))) != 0)
            {
                if (hv_Length == null)
                    hv_Length = new HTuple();
                hv_Length[hv_ZeroLengthIndices] = -1;
            }
            //
            //Calculate auxiliary variables.
            hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
            hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
            hv_HalfHeadWidth = hv_HeadWidth / 2.0;
            //
            //Calculate end points of the arrow head.
            hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
            hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
            hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
            hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
            //
            //Finally create output XLD contour for each input point pair
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
            {
                if ((int)(new HTuple(((hv_Length.TupleSelect(hv_Index))).TupleEqual(-1))) != 0)
                {
                    //Create_ single points for arrows with identical start and end point
                    ho_TempArrow.Dispose();
                    ho_TempArrow.GenContourPolygonXld(hv_Row1.TupleSelect(hv_Index),
                        hv_Column1.TupleSelect(hv_Index));
                }
                else
                {
                    //Create arrow contour
                    ho_TempArrow.Dispose();
                    ho_TempArrow.GenContourPolygonXld(((((((((((hv_Row1.TupleSelect(
                        hv_Index))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                        hv_RowP1.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                        hv_RowP2.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)),
                        ((((((((((hv_Column1.TupleSelect(hv_Index))).TupleConcat(hv_Column2.TupleSelect(
                        hv_Index)))).TupleConcat(hv_ColP1.TupleSelect(hv_Index)))).TupleConcat(
                        hv_Column2.TupleSelect(hv_Index)))).TupleConcat(hv_ColP2.TupleSelect(
                        hv_Index)))).TupleConcat(hv_Column2.TupleSelect(hv_Index)));
                }
                if (!ho_Arrow.IsInitialized())
                {
                    ho_Arrow = ho_TempArrow;
                }
                ho_Arrow = ho_Arrow.ConcatObj(ho_TempArrow);
            }
            ho_TempArrow.Dispose();

            return;
        }
        /// <summary>
        /// 图像坐标点转换为世界坐标点
        /// </summary>
        /// <param name="img">坐标信息图像</param>
        /// <param name="rows">输入坐标行</param>
        /// <param name="cols">输入坐标列</param>
        /// <param name="wX">输出世界坐标行</param>
        /// <param name="wY">输出世界坐标列</param>
        public static void Points2WorldPlane(HImageExt img, List<double> rows, List<double> cols, out List<double> wX, out List<double> wY)
        {
            wX = new List<double>();
            wY = new List<double>();
            try
            {
                HTuple xImg, yImg;
                double xAxis, yAxis;
                //相机缩放比率校正
                //xImg = img.getHomImg().AffineTransPoint2d(new HTuple(cols.ToArray()), new HTuple(rows.ToArray()), out yImg);
                Pixel2WorldPlane(img, rows, cols, out xImg, out yImg);
                xAxis = img.getHomAxis().AffineTransPoint2d(img.X, img.Y, out yAxis);

                wX = xImg.TupleAdd(xAxis).ToDArr().ToList();
                wY = yImg.TupleAdd(yAxis).ToDArr().ToList();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }
        /// <summary>
        /// 图像坐标点转换为世界坐标点
        /// </summary>
        /// <param name="img">坐标信息图像</param>
        /// <param name="row">输入坐标行</param>
        /// <param name="col">输入坐标列</param>
        /// <param name="wX">输出世界坐标行</param>
        /// <param name="wY">输出世界坐标列</param>
        public static void Points2WorldPlane(HImageExt img, double row, double col, out double wX, out double wY)
        {
            wX = 0f;
            wY = 0f;
            try
            {
                double xImg, yImg;
                double xAxis, yAxis;
                //相机缩放比率校正
                //xImg = img.getHomImg().AffineTransPoint2d(new HTuple(cols.ToArray()), new HTuple(rows.ToArray()), out yImg);
                Pixel2WorldPlane(img, row, col, out xImg, out yImg);
                xAxis = img.getHomAxis().AffineTransPoint2d(img.X, img.Y, out yAxis);

                wX = xImg + xAxis;
                wY = yImg + yAxis;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }


        /// <summary>
        /// 直线转换世界坐标系
        /// </summary>
        /// <param name="img">图片信息</param>
        /// <param name="inLine">输入直线</param>
        /// <returns>返回世界坐标系直线</returns>
        public static Line_INFO Line2WorldPlane(HImageExt img, Line_INFO inLine)
        {
            Line_INFO outLine = new Line_INFO();
            try
            {
                Points2WorldPlane(img, inLine.StartY, inLine.StartX, out outLine.StartX, out outLine.StartY);
                Points2WorldPlane(img, inLine.EndY, inLine.EndX, out outLine.EndX, out outLine.EndY);
                outLine = new Line_INFO(outLine.StartY, outLine.StartX, outLine.EndY, outLine.EndX);
                return outLine;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
                return outLine;
            }
        }
        /// <summary>
        /// 直线转换世界坐标系
        /// </summary>
        /// <param name="img">图片信息</param>
        /// <param name="inLine">输入直线</param>
        /// <returns>返回世界坐标系直线</returns>
        public static Rectangle2_INFO Rectangle2WorldPlane(HImageExt img, Rectangle2_INFO inLine)
        {
            Rectangle2_INFO outRect2 = new Rectangle2_INFO();
            try
            {
                Points2WorldPlane(img, inLine.CenterY, inLine.CenterX, out outRect2.CenterX, out outRect2.CenterY);
                //Points2WorldPlane(img, inLine.EndY, inLine.EndX, out outLine.EndX, out outLine.EndY);
                outRect2.Length1 = inLine.Length1 * (img.ScaleY + img.ScaleX) / 2;
                outRect2.Length2 = inLine.Length2 * (img.ScaleY + img.ScaleX) / 2;
                outRect2 = new Rectangle2_INFO(outRect2.CenterY, outRect2.CenterX, inLine.Phi, outRect2.Length1, outRect2.Length2);
                
                return outRect2;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
                return outRect2;
            }
        }
        /// <summary>
        /// 圆转换成世界坐标系
        /// </summary>
        /// <param name="img">图像信息</param>
        /// <param name="inCircle">输入圆</param>
        /// <returns>返回世界坐标系圆</returns>
        public static Circle_INFO Circle2WorldPlane(HImageExt img, Circle_INFO inCircle)
        {
            Circle_INFO outCircle = new Circle_INFO();
            try
            {
                Points2WorldPlane(img, inCircle.CenterY, inCircle.CenterX, out outCircle.CenterX, out outCircle.CenterY);
                outCircle.Radius = inCircle.Radius * (img.ScaleY + img.ScaleX) / 2;
                return outCircle;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
                return outCircle;
            }
        }
        /// <summary>
        /// 椭圆转换成世界坐标系
        /// </summary>
        /// <param name="img">图像信息</param>
        /// <param name="inCircle">输入椭圆</param>
        /// <returns>返回世界坐标系椭圆</returns>
        public static Ellipse_INFO Ellipse2WorldPlane(HImageExt img, Ellipse_INFO inEllipse)
        {
            Ellipse_INFO outEllipse = new Ellipse_INFO();
            try
            {
                Points2WorldPlane(img, inEllipse.CenterY, inEllipse.CenterX, out outEllipse.CenterX, out outEllipse.CenterY);
                outEllipse.Radius1 = inEllipse.Radius1 * (img.ScaleY + img.ScaleX) / 2;
                outEllipse.Radius2 = inEllipse.Radius2 * (img.ScaleY + img.ScaleX) / 2;
                return outEllipse;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString());
                return outEllipse;
            }
        }
        /// <summary>
        /// 图像坐标点转换为mm坐标点，使用区域标定的方法
        /// </summary>
        /// <param name="img">坐标信息图像</param>
        /// <param name="rows">输入坐标行</param>
        /// <param name="cols">输入坐标列</param>
        /// <param name="X">输出mm坐标行</param>
        /// <param name="Y">输出mm坐标列</param>
        public static void Pixel2WorldPlane(HImageExt img, List<double> rows, List<double> cols, out HTuple X, out HTuple Y)
        {
            X = new HTuple();
            Y = new HTuple();
            try
            {
                double xImg, yImg;
                //缩放校正
                for (int i = 0; i < rows.Count; i++)
                {
                    if (img.blnCalibrated)
                    {
                        HTuple row = HTuple.TupleGenConst(img.BoardRow.Length, rows[i]);
                        HTuple col = HTuple.TupleGenConst(img.BoardRow.Length, cols[i]);
                        HTuple distance = HMisc.DistancePp(row, col, img.BoardRow, img.BoardCol);
                        int index = distance.TupleFindFirst(distance.TupleMin()).I;
                        xImg = img.BoardX[index].D + (cols[i] - img.BoardCol[index].D) * img.ScaleX;
                        yImg = img.BoardY[index].D + (rows[i] - img.BoardRow[index].D) * img.ScaleY;
                    }
                    else
                    {
                        xImg = cols[i] * img.ScaleX;
                        yImg = rows[i] * img.ScaleY;
                    }
                    X = X.TupleConcat(xImg);
                    Y = Y.TupleConcat(yImg);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }
        /// <summary>
        /// 图像坐标点转换为mm坐标
        /// </summary>
        /// <param name="img">坐标信息图像</param>
        /// <param name="row">输入坐标行</param>
        /// <param name="col">输入坐标列</param>
        /// <param name="wX">输出mm坐标行</param>
        /// <param name="wY">输出mm坐标列</param>
        public static void Pixel2WorldPlane(HImageExt img, double row, double col, out double X, out double Y)
        {
            X = 0f; Y = 0f;
            try
            {
                if (img.blnCalibrated)
                {
                    //缩放校正
                    HTuple rows = HTuple.TupleGenConst(img.BoardRow.Length, row);
                    HTuple cols = HTuple.TupleGenConst(img.BoardRow.Length, col);
                    HTuple distance = HMisc.DistancePp(rows, cols, img.BoardRow, img.BoardCol);
                    int index = distance.TupleFindFirst(distance.TupleMin()).I;
                    X = img.BoardX[index].D + (col - img.BoardCol[index].D) * img.ScaleX;
                    Y = img.BoardY[index].D + (row - img.BoardRow[index].D) * img.ScaleY;
                }
                else
                {
                    X = col * img.ScaleX;
                    Y = row * img.ScaleY;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                Log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// mm坐标转换为图像坐标
        /// </summary>
        /// <param name="img">坐标信息图像</param>
        /// <param name="X">当前图像mm坐标X</param>
        /// <param name="Y">当前图像mm坐标Y</param>
        /// <param name="row">图像坐标row</param>
        /// <param name="col">图像坐标col</param>
        public static void ImagePlane2Pixel(HImageExt img, double X, double Y, out double row, out double col)
        {
            row = 0f; col = 0f;
            try
            {
                if (img.blnCalibrated)
                {
                    //缩放校正
                    HTuple Xs = HTuple.TupleGenConst(img.BoardCol.Length, X);
                    HTuple Ys = HTuple.TupleGenConst(img.BoardRow.Length, Y);

                    HTuple distance = HMisc.DistancePp(Xs, Ys, img.BoardX, img.BoardY);
                    int index = distance.TupleFindFirst(distance.TupleMin()).I;
                    col = img.BoardCol[index].D + (X - img.BoardX[index].D) / img.ScaleX;
                    row = img.BoardRow[index].D + (Y - img.BoardY[index].D) / img.ScaleY;
                }
                else
                {
                    col = X / img.ScaleX;
                    row = Y / img.ScaleY;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message); Log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 世界坐标转换为当前图像的像素坐标
        /// </summary>
        /// <param name="img">坐标信息图像</param>
        /// <param name="wX">世界坐标X</param>
        /// <param name="wY">世界坐标Y</param>
        /// <param name="row">图像坐标row</param>
        /// <param name="col">图像坐标col</param>
        public static void WorldPlane2Point(HImageExt img, double wX, double wY, out double row, out double col)
        {
            row = 0f; col = 0f;
            double xImg, yImg;
            try
            {
                double xAxis, yAxis;
                xAxis = img.getHomAxis().AffineTransPoint2d(img.X, img.Y, out yAxis);
                xImg = wX - xAxis;
                yImg = wY - yAxis;
                ImagePlane2Pixel(img, xImg, yImg, out row, out col);

            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message); Log.Error(ex.ToString());
            }
        }


        
        /// <summary>
        /// 矩形转换图像坐标
        /// </summary>
        /// <param name="img">图片信息</param>
        /// <param name="inLine">输入世界坐标直线</param>
        /// <returns>返回图像坐标系直线</returns>
        public static Rectangle2_INFO Rectangle2PixelPlane(HImageExt img, Rectangle2_INFO inRect)
        {
            Rectangle2_INFO outRect = new Rectangle2_INFO();
            try
            {
                WorldPlane2Point(img, inRect.CenterX, inRect.CenterY, out outRect.CenterY, out outRect.CenterX);
                //WorldPlane2Point(img, inLine.EndX, inLine.EndY, out outLine.EndY, out outLine.EndX);
                outRect.Length1 = inRect.Length1 * (img.ScaleY + img.ScaleX) / 2;
                outRect.Length2 = inRect.Length2 * (img.ScaleY + img.ScaleX) / 2;
                outRect = new Rectangle2_INFO(outRect.CenterY, outRect.CenterX, inRect.Phi, outRect.Length1, outRect.Length2);
                return outRect;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString()); Log.Error(ex.ToString());
                return outRect;
            }
        }

        /// <summary>
        /// 直线转换世界坐标系
        /// </summary>
        /// <param name="img">图片信息</param>
        /// <param name="inLine">输入世界坐标直线</param>
        /// <returns>返回图像坐标系直线</returns>
        public static Line_INFO Line2PixelPlane(HImageExt img, Line_INFO inLine)
        {
            Line_INFO outLine = new Line_INFO();
            try
            {
                WorldPlane2Point(img, inLine.StartX, inLine.StartY, out outLine.StartY, out outLine.StartX);
                WorldPlane2Point(img, inLine.EndX, inLine.EndY, out outLine.EndY, out outLine.EndX);
                outLine = new Line_INFO(outLine.StartY, outLine.StartX, outLine.EndY, outLine.EndX);
                return outLine;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString()); Log.Error(ex.ToString());
                return outLine;
            }
        }

        /// <summary>
        /// 世界坐标圆转换成当前图像坐标系
        /// </summary>
        /// <param name="img">图像信息</param>
        /// <param name="inCircle">输入圆</param>
        /// <returns>返回当前图像坐标系圆</returns>
        public static Circle_INFO Circle2PixelPlane(HImageExt img, Circle_INFO inCircle)
        {
            Circle_INFO outCircle = new Circle_INFO();
            try
            {
                WorldPlane2Point(img, inCircle.CenterX, inCircle.CenterY, out outCircle.CenterY, out outCircle.CenterX);


                outCircle.Radius = inCircle.Radius * 2 / (img.ScaleY + img.ScaleX);
                return outCircle;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString()); Log.Error(ex.ToString());
                return outCircle;
            }
        }
        /// <summary>
        /// 世界坐标系椭圆转换成图像坐标系
        /// </summary>
        /// <param name="img">图像信息</param>
        /// <param name="inEllipse">输入椭圆</param>
        /// <returns>返回当前图像坐标系椭圆</returns>
        public static Ellipse_INFO Ellipse2PixelPlane(HImageExt img, Ellipse_INFO inEllipse)
        {
            Ellipse_INFO outEllipse = new Ellipse_INFO();
            try
            {
                WorldPlane2Point(img, inEllipse.CenterX, inEllipse.CenterY, out outEllipse.CenterY, out outEllipse.CenterX);

                outEllipse.Radius1 = inEllipse.Radius1 * 2 / (img.ScaleY + img.ScaleX);
                outEllipse.Radius2 = inEllipse.Radius2 * 2 / (img.ScaleY + img.ScaleX);
                return outEllipse;
            }
            catch (System.Exception ex)
            {
                Helper.LogHandler.Instance.VTLogError(ex.ToString()); Log.Error(ex.ToString());
                return outEllipse;
            }
        }
        /// <summary>
        /// 获取坐标中心箭头-长
        /// </summary>
        /// <param name="img"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static HXLDCont GetCoord(HImageExt img, Coordinate_INFO coord)
        {
            int Width, Height;
            double row, col;
            HXLDCont CoordXLD;
            img.GetImageSize(out Width, out Height);
            HTuple row1 = new HTuple(new double[] { 0, 0 });
            HTuple col1 = new HTuple(new double[] { 0, 0 });
            HTuple row2 = new HTuple(new double[] { 0, Height / 2 });
            HTuple col2 = new HTuple(new double[] { Width / 2, 0 });
            HMeasureSet.GenArrowContourXld(out CoordXLD, row1, col1, row2, col2, 10, 10);
            HMeasureSet.WorldPlane2Point(img, coord.X, coord.Y, out row, out col);
            HHomMat2D hom = new HHomMat2D();
            hom.VectorAngleToRigid(0, 0, 0, row, col, coord.Phi);
            CoordXLD = CoordXLD.AffineTransContourXld(hom);
            return CoordXLD;
        }
        /// <summary>
        /// 获取坐标中心箭头-短
        /// </summary>
        /// <param name="img"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        public static HXLDCont GetCoordShort(HImageExt img, Coordinate_INFO coord)
        {
            int Width, Height;
            double row, col;
            HXLDCont CoordXLD;
            img.GetImageSize(out Width, out Height);
            HTuple row1 = new HTuple(new double[] { 0, 0 });
            HTuple col1 = new HTuple(new double[] { 0, 0 });
            HTuple row2 = new HTuple(new double[] { 0, Height / 2 });
            HTuple col2 = new HTuple(new double[] { Width / 2, 0 });
            HMeasureSet.GenArrowContourXld(out CoordXLD, row1, col1, row2/30, col2/20, 4, 4);
            HMeasureSet.WorldPlane2Point(img, coord.X, coord.Y, out row, out col);
            HHomMat2D hom = new HHomMat2D();
            hom.VectorAngleToRigid(0, 0, 0, row, col, coord.Phi);
            CoordXLD = CoordXLD.AffineTransContourXld(hom);
            return CoordXLD;
        }
        /// <summary>
        /// 获取区域中心
        /// </summary>
        /// <param name="img">图像信息</param>
        /// <param name="inEllipse">输入椭圆</param>
        /// <returns>返回当前图像坐标系椭圆</returns>
        public static void  GetAreaCenter(HRegion region,out double area, out double row, out double col)
        {

            HTuple _ROW = null, _COL = null, _Area = null;
            HOperatorSet.AreaCenter(region,out _Area, out _ROW, out _COL);
            row = _ROW;
            col=_COL;
            area = _Area;

        }
        /// <summary>
        /// 图像旋转变换
        /// </summary>
        /// <param name="img"></param>
        /// <param name="ImgAdjustMode"></param>
        /// <returns></returns>
        public static HImage AffineImage(HImage img, IMG_ADJUST ImgAdjustMode)
        {
            HImage tempImg = new HImage();

            switch (ImgAdjustMode)
            {
                case IMG_ADJUST.None:
                    tempImg = img.Clone();
                    break;
                case IMG_ADJUST.垂直镜像:
                    tempImg = img.MirrorImage("row");
                    break;
                case IMG_ADJUST.水平镜像:
                    tempImg = img.MirrorImage("column");
                    break;
                case IMG_ADJUST.顺时针90度:
                    tempImg = img.RotateImage(270.0, "nearest_neighbor");
                    break;
                case IMG_ADJUST.逆时针90度:
                    tempImg = img.RotateImage(90.0, "nearest_neighbor");
                    break;
                case IMG_ADJUST.旋转180度:
                    tempImg = img.RotateImage(180.0, "nearest_neighbor");
                    break;
            }
            return tempImg;
        } 
        public static void FindBarCorde(HImage img, HObject _SymbolXLDs, HTuple _DataCodeHandle, int _CordeNum, HTuple _CodeType, out HXLDCont _Corde2DXLD, out string _DecodedDataStrings)
        {
            string m_BarCorde = "";
            HObject m_SymbolXLDs = new HObject();
            HTuple m_DecodedDataStrings = new HTuple();
            m_DecodedDataStrings = "";
            try
            {
                HOperatorSet.FindBarCode(img, out m_SymbolXLDs, _DataCodeHandle, _CodeType, out m_DecodedDataStrings);
                _Corde2DXLD = new HRegion(m_SymbolXLDs);

                for (int i = 0; i < m_DecodedDataStrings.Length; ++i)
                {
                    m_BarCorde += m_DecodedDataStrings[i] + "\r\n";
                }
                _DecodedDataStrings = m_BarCorde;
            } 
            catch (Exception ex) { _Corde2DXLD = new HXLDCont(); _DecodedDataStrings="Error"; Debug.WriteLine(ex.ToString()); m_BarCorde = "Error"; Log.Error(ex.ToString()); }
          

        }
        /// <summary>
        /// 二维码读取
        /// </summary>
        /// <param name="img">输入图像</param>
        /// <param name="_SymbolXLDs">轮廓</param>
        /// <param name="_DataCodeHandle">句柄</param>
        /// <param name="_Corde2DXLD">输出轮廓</param>
        /// <param name="_DecodedDataStrings">条码内容</param>
        /// <returns></returns>
        ///ToDo:二维码读取
        public static void FindCorde2D(HImage img, HObject _SymbolXLDs, HTuple _DataCodeHandle, int _CordeNum, HTuple _ResultHandles, out HXLDCont _Corde2DXLD, out string _DecodedDataStrings)
        {
            string m_Corde2D = "";
            HObject m_SymbolXLDs = new HObject();
            HTuple m_ResultHandles = new HTuple();
            HTuple m_DecodedDataStrings = new HTuple();
            m_DecodedDataStrings = "";
           // HTuple m_DataCodeHandle;

           /* HOperatorSet.CreateDataCode2dModel("GS1 DataMatrix", "default_parameters", "standard_recognition", out m_DataCodeHandle);*/
            // HOperatorSet.FindDataCode2d(img, out m_SymbolXLDs, _DataCodeHandle, "train", "all", out m_ResultHandles, out m_DecodedDataStrings);
           // HImage m_img = new HImage("E:\\图片\\images\\datacode\\gs1datamatrix\\gs1datamatrix_generated_01.png");

            HOperatorSet.FindDataCode2d(img, out m_SymbolXLDs, _DataCodeHandle, new HTuple("stop_after_result_num"), new HTuple(_CordeNum), out m_ResultHandles, out m_DecodedDataStrings);
            _Corde2DXLD = new HXLDCont(m_SymbolXLDs);
            for (int i = 0; i < m_DecodedDataStrings.Length; ++i)
            {
                m_Corde2D += m_DecodedDataStrings[i] + "\r\n";
            }
            _DecodedDataStrings = m_Corde2D;
        }



        /// <summary>
        /// 使用脚本显示文本输出
        /// 脚本实例
        /// dim rowList, colList as new List(of double)
        /// rowList.add(100)
        /// colList.add(100)
        /// h.SetCrossShow(15,rowList,colList)
        /// h.SetLineShow(15,100,100,2000,2000)
        /// h.SetTextShow(15,"显示的内容",500,500,"mono",50,"red")
        /// </summary>
        /// <param name="unitID">要显示的工具单元</param>
        /// <param name="_text">文本信息</param>
        /// <param name="_row">行</param>
        /// <param name="_col">列</param>
        /// <param name="_font">字体</param>
        /// <param name="_size">文字大小</param>
        /// <param name="_color">文字颜色</param>
        /// ToDo:文本框显示
        //public static void SetTextShow(int unitID, string _text, double _row, double _col, string _font, int _size, string _color)
        //{
        //    CMeasureCell cell = HMeasureSYS.g_ProjectList[m_ProIndex].m_CellList.First(c => c.m_CellID == unitID);

        //    MeasureROIText roiText = new MeasureROIText(_text, _row, _col, _font, _size, _color);
        //    ((CMeasure_Show)cell).genTextShow(roiText);
        //}
        /// <summary>
        /// /使用halcon的拟合直线算法,比fitLine更准确,因为有其自己的剔除异常点算法
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="line"></param>
        /// <returns>结果直线</returns>
        public static bool FitLine(List<double> rows, List<double> cols, out ROILine line)
        {
            line = new ROILine();
            try
            {
                SortPairs(ref rows, ref cols);
                HXLDCont lineXLD = new HXLDCont(new HTuple(rows.ToArray()), new HTuple(cols.ToArray()));
                lineXLD.FitLineContourXld("tukey", -1, 0, 5, 2, out double rowBegin, out double colBegin, out double rowEnd, out double colEnd, out double nr, out double nc, out double dist);//tukey剔除算法为halcon推荐算法
                line = new ROILine(Math.Round(rowBegin, 4), Math.Round(colBegin, 4), Math.Round(rowEnd, 4), Math.Round(colEnd, 4));
                return true;
            }
            catch (Exception)
            {
                line.Status = false;
                return false;
            }
        }

        /// <summary>
        /// 最小二乘法圆拟合
        /// </summary>
        /// <param name="rows">点云 行坐标</param>
        /// <param name="cols">点云 列坐标</param>
        /// <param name="circle">返回圆</param>
        /// <returns>是否拟合成功</returns>
        public static bool FitCircle(double[] rows, double[] cols, out Circle_INFO circle)
        {
            circle = new Circle_INFO();
            if (cols.Length < 3)
            {
                return false;
            }
            //本地代码验证通过------20180827 yoga
            ////原始托管代码
            double sum_x = 0.0f, sum_y = 0.0f;
            double sum_x2 = 0.0f, sum_y2 = 0.0f;
            double sum_x3 = 0.0f, sum_y3 = 0.0f;
            double sum_xy = 0.0f, sum_x1y2 = 0.0f, sum_x2y1 = 0.0f;

            int N = cols.Length;
            for (int i = 0; i < N; i++)
            {
                double x = rows[i];
                double y = cols[i];
                double x2 = x * x;
                double y2 = y * y;
                sum_x += x;
                sum_y += y;
                sum_x2 += x2;
                sum_y2 += y2;
                sum_x3 += x2 * x;
                sum_y3 += y2 * y;
                sum_xy += x * y;
                sum_x1y2 += x * y2;
                sum_x2y1 += x2 * y;
            }

            double C, D, E, G, H;
            double a, b, c;

            C = N * sum_x2 - sum_x * sum_x;
            D = N * sum_xy - sum_x * sum_y;
            E = N * sum_x3 + N * sum_x1y2 - (sum_x2 + sum_y2) * sum_x;
            G = N * sum_y2 - sum_y * sum_y;
            H = N * sum_x2y1 + N * sum_y3 - (sum_x2 + sum_y2) * sum_y;
            a = (H * D - E * G) / (C * G - D * D);
            b = (H * C - E * D) / (D * D - G * C);
            c = -(a * sum_x + b * sum_y + sum_x2 + sum_y2) / N;
            circle.CenterY = Math.Round(a / (-2), 4);
            circle.CenterX = Math.Round(b / (-2), 4);
            circle.Radius = Math.Round(Math.Sqrt(a * a + b * b - 4 * c) / 2, 4);
            return true;
        }

        /// <summary>
        /// 最小二乘法圆拟合
        /// </summary>
        /// <param name="rows">点云 行坐标</param>
        /// <param name="cols">点云 列坐标</param>
        /// <param name="circle">返回圆</param>
        /// <returns>是否拟合成功</returns>
        public static bool FitCircle1(List<double> rows, List<double> cols, out ROICircle circle)
        {
            circle = new ROICircle();
            if (cols.Count < 3)
            {
                circle.Status = false;
                return false;
            }
            //本地代码验证通过------20180827 yoga
            ////原始托管代码
            double sum_x = 0.0f, sum_y = 0.0f;
            double sum_x2 = 0.0f, sum_y2 = 0.0f;
            double sum_x3 = 0.0f, sum_y3 = 0.0f;
            double sum_xy = 0.0f, sum_x1y2 = 0.0f, sum_x2y1 = 0.0f;

            int N = cols.Count;
            for (int i = 0; i < N; i++)
            {
                double x = rows[i];
                double y = cols[i];
                double x2 = x * x;
                double y2 = y * y;
                sum_x += x;
                sum_y += y;
                sum_x2 += x2;
                sum_y2 += y2;
                sum_x3 += x2 * x;
                sum_y3 += y2 * y;
                sum_xy += x * y;
                sum_x1y2 += x * y2;
                sum_x2y1 += x2 * y;
            }

            double C, D, E, G, H;
            double a, b, c;

            C = N * sum_x2 - sum_x * sum_x;
            D = N * sum_xy - sum_x * sum_y;
            E = N * sum_x3 + N * sum_x1y2 - (sum_x2 + sum_y2) * sum_x;
            G = N * sum_y2 - sum_y * sum_y;
            H = N * sum_x2y1 + N * sum_y3 - (sum_x2 + sum_y2) * sum_y;
            a = (H * D - E * G) / (C * G - D * D);
            b = (H * C - E * D) / (D * D - G * C);
            c = -(a * sum_x + b * sum_y + sum_x2 + sum_y2) / N;
            circle.CenterY = Math.Round(a / (-2), 4);
            circle.CenterX = Math.Round(b / (-2), 4);
            circle.Radius = Math.Round(Math.Sqrt(a * a + b * b - 4 * c) / 2, 4);
            return true;
        }
        /// <summary>
        /// 计算rms误差
        /// </summary>
        /// <param name="hom2d"></param>
        /// <param name="x_Image"></param>
        /// <param name="y_Image"></param>
        /// <param name="x_Robot"></param>
        /// <param name="y_Robot"></param>
        /// <returns></returns>
        public static double CalRMS(HHomMat2D hom2d, HTuple x_Image, HTuple y_Image, HTuple x_Robot, HTuple y_Robot)
        {
            try
            {
                double count = 0;
                for (int i = 0; i < x_Image.Length; i++)
                {
                    double tempX, tempY;
                    tempX = hom2d.HomMat2dInvert().AffineTransPoint2d(x_Robot[i].D, y_Robot[i].D, out tempY);

                    double dis = HMisc.DistancePp(tempY, tempX, y_Image[i], x_Image[i]);
                    count = count + dis * dis;
                }
                double RMS = Math.Sqrt(count / x_Image.Length);
                return RMS;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        /// <summary>点集合到线的距离</summary>
        public static void DisPL(List<double> rows, List<double> cols, ROILine Line1, out List<double> dis)
        {
            dis = new List<double>() { -999.999 };
            HTuple disT = HMisc.DistancePl(new HTuple(rows.ToArray()), new HTuple(cols.ToArray()), new HTuple(Line1.StartY), new HTuple(Line1.StartX), new HTuple(Line1.EndY), new HTuple(Line1.EndX));
            dis = disT.ToDArr().ToList();
        }
        /// <summary>点集合到线的距离</summary>
        public static double DisPL(double X, double Y, ROILine line)
        {
            return HMisc.DistancePl(X, Y, line.StartX, line.StartY, line.EndX, line.EndY);
        }
        /// <summary>点集合到线的距离</summary>
        public static double[] DisPL(double[] X, double[] Y, ROILine line)
        {
            double[] DisList = new double[X.Length];
            for (int i = 0; i < X.Length; i++)
            {
                DisList[i] = HMisc.DistancePl(X[i], Y[i], line.StartX, line.StartY, line.EndX, line.EndY);
            }
            return DisList;
        }
        /// <summary>点集合到线的距离</summary>
        public static double DisPL(RPoint point, ROILine line, ValueMode mode)
        {
            try
            {
                double[] DisList = new double[point.X1.Length];
                for (int i = 0; i < point.X1.Length; i++)
                {
                    DisList[i] = HMisc.DistancePl(point.X1[i], point.Y1[i], line.StartX, line.StartY, line.EndX, line.EndY);
                }
                switch (mode)
                {
                    case ValueMode.最大值:
                        return DisList.Max();
                    case ValueMode.最小值:
                        return DisList.Min();
                    case ValueMode.平均值:
                        return DisList.Average();
                }
            }
            catch { }
            return 0.0;
        }
        /// <summary>线线距离</summary>
        public static double DisLL(ROILine line1, ROILine line2, ValueMode mode)
        {
            HMisc.DistanceSl(line1.StartX, line1.StartY, line1.EndX, line1.EndY, line2.StartX, line2.StartY, line2.EndX, line2.EndY, out double Mindistance, out double Maxdistance);
            //HOperatorSet.DistanceCc(line1.GetXLD(), line2.GetXLD(), "point_to_point", out HTuple Mindistance, out HTuple Maxdistance);//point_to_segment
            switch (mode)
            {
                case ValueMode.最大值:
                    return Maxdistance;
                case ValueMode.最小值:
                    return Mindistance;
            }
            return 0;
        }
        /// <summary>计算两条直线的距离</summary>
        public static double DisLL(ROILine Line1, ROILine Line2)
        {
            ROILine line_C = new ROILine();
            //Line 向量夹角
            double L1 = (Line1.EndX - Line1.StartX) * (Line2.EndX - Line2.StartX) + (Line1.EndY - Line1.StartY) * (Line2.EndY - Line2.StartY);
            double L2 = Math.Sqrt(Math.Pow(Line1.EndX - Line1.StartX, 2) + Math.Pow(Line1.EndY - Line1.StartY, 2)) * Math.Sqrt(Math.Pow(Line2.EndX - Line2.StartX, 2) + Math.Pow(Line2.EndY - Line2.StartY, 2));
            double cosT = L1 / L2;
            if (Math.Abs(Math.Acos(cosT)) > Math.PI / 2)
            {
                line_C.StartY = (Line1.StartY + Line2.EndY) / 2;
                line_C.StartX = (Line1.StartX + Line2.EndX) / 2;
                line_C.EndY = (Line1.EndY + Line2.StartY) / 2;
                line_C.EndX = (Line1.EndX + Line2.StartX) / 2;
            }
            else
            {
                line_C.StartY = (Line1.StartY + Line2.StartY) / 2;
                line_C.StartX = (Line1.StartX + Line2.StartX) / 2;
                line_C.EndY = (Line1.EndY + Line2.EndY) / 2;
                line_C.EndX = (Line1.EndX + Line2.EndX) / 2;
            }
            double Distance1 = HMisc.DistancePl((Line1.StartY + Line1.EndY) / 2, (Line1.StartX + Line1.EndX) / 2, line_C.StartY, line_C.StartX, line_C.EndY, line_C.EndX);
            double Distance2 = HMisc.DistancePl((Line2.StartY + Line2.EndY) / 2, (Line2.StartX + Line2.EndX) / 2, line_C.StartY, line_C.StartX, line_C.EndY, line_C.EndX);
            return Distance1 + Distance2;
        }
        /// <summary>点集合到点集合的距离</summary>
        public static void DisPP(List<double> rows1, List<double> cols1, List<double> rows2, List<double> cols2, out List<double> dis)
        {
            dis = new List<double>();
            try
            {
                List<int> MinLenght = new List<int>();
                MinLenght.Add(rows1.Count);
                MinLenght.Add(cols1.Count);
                MinLenght.Add(rows2.Count);
                MinLenght.Add(cols2.Count);
                int index = MinLenght.Min();
                while (index < rows1.Count)
                {
                    rows1.RemoveAt(rows1.Count - 1);
                }
                while (index < cols1.Count)
                {
                    cols1.RemoveAt(cols1.Count - 1);
                }
                while (index < rows2.Count)
                {
                    rows2.RemoveAt(rows2.Count - 1);
                }
                while (index < cols2.Count)
                {
                    cols2.RemoveAt(cols2.Count - 1);
                }
                HTuple disT = HMisc.DistancePp(new HTuple(rows1.ToArray()), new HTuple(cols1.ToArray()), new HTuple(rows2.ToArray()), new HTuple(cols2.ToArray()));
                dis = disT.ToDArr().ToList();
            }
            catch (Exception ex)
            { }
        }
        /// <summary>点到点的距离</summary>
        public static double DisPP(double rows1, double cols1, double rows2, double cols2)
        {
            return HMisc.DistancePp(rows1, cols1, rows2, cols2);
        }
        /// <summary>点点距离</summary>
        public static double DisPP(RPoint point1, RPoint point2)
        {
            return HMisc.DistancePp(point1.X, point1.Y, point2.X, point2.Y);
        }
        /// <summary>两条直线交点</summary>
        /// <param name="isParallel">平行1，不平行0</param>
        public static void IntersectionLl(ROILine line1, ROILine line2, out double row, out double col, out int isParallel)
        {
            row = 0.0; col = 0.0; isParallel = 0;
            HMisc.IntersectionLl(line1.StartY, line1.StartX, line1.EndY, line1.EndX, line2.StartY, line2.StartX, line2.EndY, line2.EndX, out row, out col, out isParallel);
        }
        /// <summary>两条直线交点</summary>
        /// <param name="isParallel">平行1，不平行0</param>
        public static void IntersectionLc(ROILine line, ROICircle circle, out double row, out double col)
        {
            //HOperatorSet.IntersectionLineCircle(HTuple lineRow1, HTuple lineColumn1, HTuple lineRow2, HTuple lineColumn2, 
            //HTuple circleRow, HTuple circleColumn, HTuple circleRadius, HTuple circleStartPhi, HTuple circleEndPhi, HTuple circlePointOrder, out HTuple row, out HTuple column);
            HOperatorSet.IntersectionLineCircle(line.StartX, line.StartY, line.EndX, line.EndY,
                circle.CenterX, circle.CenterY, circle.Radius, circle.StartPhi, circle.EndPhi, "positive", out HTuple mRow, out HTuple mCol);
            row = mRow;
            col = mCol;
        }
        /// <summary>
        /// 求已知直线的垂线
        /// </summary>
        /// <param name="srcLine"></param>
        /// <returns>结果垂线</returns>
        public static ROILine VerticalLine(ROILine srcLine)
        {
            ROILine outLine = new ROILine();
            double rawx1 = srcLine.StartY;
            double rawy1 = srcLine.StartX;
            double rawx2 = srcLine.EndY;
            double rawy2 = srcLine.EndX;
            double k = 0;
            double minusy = rawy2 - rawy1;
            double minusx = rawx2 - rawx1;
            k = -1.0 / (minusy / minusx);
            outLine.StartX = (rawy2 + rawy1) / 2.0;
            outLine.StartY = (rawx2 + rawx1) / 2.0;
            outLine.EndY = Math.Min(rawx1, rawx2) + Math.Abs(rawx1 - rawx2) / 4.0;
            outLine.EndX = k * (outLine.EndY - outLine.StartY) + outLine.StartX;
            return outLine;
        }
        /// <summary>
        /// 计算两直线夹角
        /// </summary>
        /// <param name="Line1"></param>
        /// <param name="Line2"></param>
        /// <returns>返回弧度值</returns>
        public static double LLAngle(ROILine Line1, ROILine Line2)
        {
            HTuple angle = new HTuple();
            HOperatorSet.AngleLl(new HTuple(Line1.StartY), new HTuple(Line1.StartX), new HTuple(Line1.EndY), new HTuple(Line1.EndX),
                new HTuple(Line2.StartY), new HTuple(Line2.StartX), new HTuple(Line2.EndY), new HTuple(Line2.EndX), out angle);
            return angle[0].D;
        }
        /// <summary>求点到线的垂足</summary>
        /// <param name="inRow">点inRow，即y</param>
        /// <param name="inCol">点inCol，即x</param>
        /// <param name="srcLine">直线line</param>
        /// <param name="outY">垂足outY，即y</param>
        /// <param name="outX">垂足outX，即x</param>
        public static void PLPedal(double X, double Y, ROILine line, out double outY, out double outX, out double Dis)
        {
            HMisc.ProjectionPl(X, Y, line.StartX, line.StartY, line.EndX, line.EndY, out outX, out outY);
            Dis = HMisc.DistancePl(X, Y, line.StartX, line.StartY, line.EndX, line.EndY);
        }
        /// <summary>计算弧度</summary>
        public static double GenAngle(RPoint point1, RPoint point2)
        {
            return HMisc.AngleLx(point1.Y, point1.X, point2.Y, point2.X);
            ////两点的x、y值
            //double x = x1 - x2;
            //double y = y1 - y2;
            ////斜边长度
            //double hypotenuse = Math.Sqrt(Math.Pow(x, 2f) + Math.Pow(y, 2f));
            ////求出弧度
            //double cos = x / hypotenuse;
            //double Phi = Math.Acos(cos);
            //if (y < 0)
            //{
            //    Phi = -Phi;
            //}
            //else if ((y == 0) && (x < 0))
            //{
            //    Phi = Math.PI;
            //}
            //return Phi;
        }

        /// <summary>
        /// 通过RectList来计算平面度
        /// </summary>
        /// <param name="rectList">矩阵列表</param>
        /// <param name="type">计算方法 List-所有点参与计算 min-区域最小值参与计算 max-区域最大值参与计算 avg-区域平均值参与计算 med-区域中值参与计算 </param>
        /// <returns></returns>
        public static Plane_INFO CalPlaneByRectList(List<RectRoiInfo> rectList, string type)
        {
            Plane_INFO Plane = new Plane_INFO();
            try
            {
                type = type.Trim().ToUpper();
                List<double> xList = new List<double>();
                List<double> yList = new List<double>();
                List<double> zList = new List<double>();
                if (type == "LIST")
                {
                    foreach (RectRoiInfo rect in rectList)
                    {
                        xList = xList.Concat(rect.X_List).ToList();
                        yList = yList.Concat(rect.Y_List).ToList();
                        zList = zList.Concat(rect.Value_List).ToList();
                    }
                }
                else
                {
                    foreach (RectRoiInfo rect in rectList)
                    {
                        xList.Add(rect.X);
                        yList.Add(rect.Y);
                        if (type == "MAX")
                            zList.Add(rect.Value_Max);
                        else if (type == "MIN")
                            zList.Add(rect.Value_Min);
                        else if (type == "AVG")
                            zList.Add(rect.Value_Avg);
                        else if (type == "MED")
                            zList.Add(rect.Value_Median);
                    }
                }

                Plane = Fit.FitPlane(xList, yList, zList);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            return Plane;
        }

        /// <summary>
        ///  求两向量之间的夹角
        /// </summary>
        /// <param name="v1">  tagVector</param>
        /// <param name="v2">tagVector</param>
        /// <param name="LinePlane"></param>
        /// <returns> 0:表示两直线之间的夹角,其它值:表示如线与平面之间,平面与平面之间的夹角(0~90)</returns>
        public static double Intersect(tagVector v1, tagVector v2, long LinePlane = 0)
        {
            //LinePlane 0 :line -line ,1:line --Plane
            double tmp, tmpSqr1, tmpSqr2;
            tmp = (v1.a * v2.a + v1.b * v2.b + v1.c * v2.c);
            //'MsgBox tm
            tmpSqr1 = Math.Sqrt(v1.a * v1.a + v1.b * v1.b + v1.c * v1.c);
            tmpSqr2 = Math.Sqrt(v2.a * v2.a + v2.b * v2.b + v2.c * v2.c);
            if (tmpSqr1 != 0)
            {
                if (tmpSqr2 != 0)
                {
                    tmp = tmp / tmpSqr1 / tmpSqr2;
                }
                else
                {
                    tmp = tmp / tmpSqr1;
                }
            }
            else
            {
                if (tmpSqr2 != 0)
                    tmp = tmp / tmpSqr2;
                else
                    tmp = 0;
            }
            if (LinePlane != 0)
            {
                tmp = Math.Abs(tmp);
            }
            if (-tmp * tmp + 1 != 0)
            {
                tmp = Math.Atan(-tmp / Math.Sqrt(-tmp * tmp + 1)) + 2 * Math.Atan(1.0);
                tmp = tmp / Math.PI * 180;
            }
            else
            {
                tmp = 90;
            }
            return tmp;
        }

        /// <summary>
        /// 求点到平面的距离
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="Plane"></param>
        /// <returns>距离值</returns>
        public static double PointToPlane(double x, double y, double z, Plane_INFO Plane)
        {
            double tmp = (Plane.ax * x + Plane.by * y + Plane.cz * z + Plane.d)
            / Math.Sqrt(Plane.ax * Plane.ax + Plane.by * Plane.by + Plane.cz * Plane.cz);
            return tmp;
        }

        /// <summary>
        /// 求两条边的中心基准线
        /// </summary>
        /// <param name="line1">输入直线1</param>
        /// <param name="line2">输入直线2</param>
        /// <returns>结果基准线</returns>
        public static ROILine middleLine(ROILine line1, ROILine line2)
        {
            try
            {
                double phi1 = HMisc.AngleLx(line1.StartY, line1.StartX, line1.EndY, line1.EndX);
                double phi2 = HMisc.AngleLx(line2.StartY, line2.StartX, line2.EndY, line2.EndX);
                double angle = Math.Abs(phi1 - phi1) * 180 / Math.PI;
                if (angle < 90 || angle > 270)
                {
                    double StartY = (line1.StartY + line2.StartY) / 2;
                    double StartX = (line1.StartX + line2.StartX) / 2;
                    double EndY = (line1.EndY + line2.EndY) / 2;
                    double EndX = (line1.EndX + line2.EndX) / 2;
                    ROILine outLine = new ROILine(StartY, StartX, EndY, EndX);
                    return outLine;
                }
                else
                {
                    double StartY = (line1.StartY + line2.EndY) / 2;
                    double StartX = (line1.StartX + line2.EndX) / 2;
                    double EndY = (line1.EndY + line2.StartY) / 2;
                    double EndX = (line1.EndX + line2.StartX) / 2;
                    ROILine outLine = new ROILine(StartY, StartX, EndY, EndX);
                    return outLine;
                }
            }
            catch (Exception ex)
            {
                return line1;
            }
        }

    }

    namespace UserDefine
    {
        /// <summary>
        /// 测量信息- 长/2,宽/2,阈值,间隔,参数名,参数值,点顺序 (0位默认，1 顺时针，2 逆时针)
        /// </summary>
        [Serializable]
        public class Text_Info
        {
            /// <summary>名称</summary>
            public string Name;
            /// <summary>链接</summary>
            public string Likes;
            /// <summary>值</summary>
            public string Value;
            public Text_Info(string _Name, string _Likes, string _Value)
            {

                Name = _Name;
                Likes = _Likes;
                Value = _Value;
            }
        }

        [Serializable]
        public enum ROIType
        {
            /// <summary>
            /// 直线
            /// </summary>
            Line = 10,
            /// <summary>
            /// 圆
            /// </summary>
            Circle,
            /// <summary>
            /// 圆弧
            /// </summary>
            CircleArc,
            /// <summary>
            /// 矩形
            /// </summary>
            Rectangle1,
            /// <summary>
            /// 带角度矩形
            /// </summary>
            Rectangle2
        }

        [Serializable]
        public abstract class ROI
        {
            private string _Color = "#00FF00";
            public string sColor
            {
                get { return _Color; }
                set { _Color = value; }
            }
            public abstract HRegion genRegion();
            public abstract HXLDCont genXLD();
            public abstract HTuple getTuple();
        }

        /// <summary>
        ///这个类是一个基类，包含用于处理的虚拟方法
        ///ROI因此，继承类需要定义/重写这些
        ///为ROIController提供必要信息的方法
        ///它(= ROIs)的形状和位置。示例项目提供
        ///导出矩形、直线、圆和圆弧的ROI形状。
        ///要使用其他形状，必须从基类派生一个新类
        ///实现它的方法。
        /// </summary>    
        [Serializable]
        public class ROI2
        {
            /// <summary> 要显示roi的图像宽度</summary>
            private int ImageWidth;
            /// <summary> 要显示roi的图像宽度</summary>
            private int ImageHight;
            /// <summary>ROI颜色 </summary>
            public string Color = "blue";
            /// <summary> ROI类型</summary>
            public ROIType Type;
            /// <summary>继承ROI类的类成员 </summary>
            protected int NumHandles;
            /// <summary>激活ID</summary>
            protected int ActiveHandleId;
            /// <summary>参数来定义ROI的线条样式。</summary>
            public HTuple FlagLineStyle;
            /// <summary>常数为负ROI标志。+</summary>
            public const int POSITIVE_FLAG = 21;
            /// <summary>常数为负ROI标志。-</summary>
            public const int NEGATIVE_FLAG = 22;
            /// <summary> 标记定义ROI为“正”或“负”。. </summary>
            protected int OperatorFlag;
            /// <summary> "+"方式直接直线 </summary>
            protected HTuple posOperation = new HTuple();
            /// <summary> "-"方式的虚线/// </summary>
            protected HTuple negOperation = new HTuple(new int[] { 2, 2 });
            /// <summary>抽象ROI类的构造函数。</summary>
            public ROI2() { }
            public virtual void CreateLine(double beginRow, double beginCol, double endRow, double endCol) { }
            public virtual void CreateCircle(double row, double col, double radius) { }
            public virtual void CreateCircleAre(double row, double col, double radius) { }
            public virtual void CreateRectangle1(double row1, double col1, double row2, double col2) { }
            public virtual void CreateRectangle2(double row, double col, double phi, double length1, double length2) { }
            /// <summary>在鼠标位置创建一个新的ROI实例。</summary>
            public virtual void CreateROI(double midX, double midY) { }
            /// <summary>将ROI绘制到提供的窗口中。</summary>
            public virtual void Draw(HWindow window) { }
            /// <summary> 返回ROI句柄的距离,最近的图像点(x,y)
            public virtual double DistToClosestHandle(double x, double y) { return 0.0; }
            /// <summary>将ROI对象的活动句柄绘制到提供的窗口中。 </summary>
            public virtual void DisplayActive(HWindow window) { }
            /// <summary> 重新计算ROI的形状。翻译是,在ROI对象的活动句柄上执行,为图像坐标(x,y)。/// </summary>
            public virtual void moveByHandle(double x, double y) { }
            /// <summary>获取ROI描述的HALCON轮廓</summary>
            public virtual HXLDCont GetXLD() { return null; }
            /// <summary>获取ROI描述的HALCON区域</summary>
            public virtual HRegion GetRegion() { return null; }
            /// <summary> 从起点得到距离 </summary>
            public virtual double GetDistanceFromStartPoint(double row, double col) { return 0.0; }
            /// <summary>获取所描述的模型信息 </summary> 
            public virtual HTuple GetModelData() { return null; }
            /// <summary>为ROI定义的句柄数。</summary>
            public int GetNumHandles() { return NumHandles; }
            /// <summary>获取ROI的活动句柄,返回索引</summary>
            public int GetActHandleIdx() { return ActiveHandleId; }
            /// <summary>获取ROI对象的符号，线的样式：+|- </summary>
            public int GetOperatorFlag() { return OperatorFlag; }
            /// <summary>设置ROI对象的符号，线的样式：+|- </summary>
            public void SetOperatorFlag(int flag)
            {
                OperatorFlag = flag;
                switch (OperatorFlag)
                {
                    case POSITIVE_FLAG:
                        FlagLineStyle = posOperation;
                        break;
                    case NEGATIVE_FLAG:
                        FlagLineStyle = negOperation;
                        break;
                    default:
                        FlagLineStyle = posOperation;
                        break;
                }
            }
        }//end of class

        /// <summary>
        /// 直线信息
        /// </summary>
        [Serializable]
        public struct Line_INFO
        {
            public double StartY;//起点行坐标
            public double StartX;//起点列坐标
            public double EndY; //终点行坐标
            public double EndX;//终点列坐标
            public double Ny;//行向量
            public double Nx;//列向量
            public double Dist;//距离
            public double Phi;//方向
            public double MidY;//中间点行坐标
            public double MidX;//中间点列坐标
            public Line_INFO(double m_start_Row, double m_start_Col, double m_end_Row, double m_end_Col)
            {
                //r*Ny+c*Nx-Dist=0
                ///AX+BY+C=0        
                //A = Y2 - Y1
                //B = X1 - X2
                //C = X2*Y1 - X1*Y2
                this.StartY = m_start_Row;
                this.StartX = m_start_Col;
                this.EndY = m_end_Row;
                this.EndX = m_end_Col;
                this.Ny = m_start_Col - m_end_Col;
                this.Nx = m_end_Row - m_start_Row;
                this.Dist = m_start_Col * m_end_Row - m_end_Col * m_start_Row;
                Phi = HMisc.AngleLx(StartY, StartX, EndY, EndX);
                MidY = (StartY + EndY) / 2;
                MidX = (StartX + EndX) / 2;

            }
            public HXLDCont genXLD()
            {
                HXLDCont xld = new HXLDCont();
                HMeasureSet.GenArrowContourXld(out xld, StartY, StartX, EndY, EndX, 10, 10);
                return xld;
            }
            public HTuple getTuple()
            {
                double[] line = new double[] { StartY, StartX, EndY, EndX };
                return new HTuple(line);
            }
        };

        /// <summary>
        /// 面信息
        /// </summary>
        [Serializable]
        public struct Plane_INFO
        {
            public double x, y, z;     //The distance from the origin to the centroid, as measured along the x-axis.
            public double ax, by, cz, d;//Z + A*x + B*y + C =0  z's coefficient is just 1
            public double Angle;
            public double xAn, yAn, zAn;
            public double Flat, MinFlat, MaxFlat;
            public double MinZ, MaxZ;
        };

        [Serializable]
        public struct tagVector
        {
            public double a, b, c;
        };

        /// <summary>
        /// 圆信息
        /// </summary>
        [Serializable]
        public class Circle_INFO : ROI, ICloneable
        {
            public double CenterY, CenterX, Radius;
            public double StartPhi = 0.0, EndPhi = Math.PI * 2;
            public string PointOrder = "positive";
            public Circle_INFO()
            {
            }
            public Circle_INFO(double m_Row_center, double m_Column_center, double m_Radius)
            {
                this.CenterY = m_Row_center;
                this.CenterX = m_Column_center;
                this.Radius = m_Radius;
            }
            public Circle_INFO(double m_Row_center, double m_Column_center, double m_Radius, double m_StartPhi, double m_EndPhi, string m_PointOrder)
            {
                this.CenterY = m_Row_center;
                this.CenterX = m_Column_center;
                this.Radius = m_Radius;
                this.StartPhi = m_StartPhi;
                this.EndPhi = m_EndPhi;
            }
            public override HRegion genRegion()
            {
                HRegion h = new HRegion();
                h.GenCircle(CenterY, CenterX, Radius);
                return h;
            }
            public override HXLDCont genXLD()
            {
                HXLDCont xld = new HXLDCont();
                xld.GenCircleContourXld(CenterY, CenterX, Radius, StartPhi, EndPhi, PointOrder, 1.0);
                return xld;
            }

            public override HTuple getTuple()
            {
                double[] circle = new double[] { CenterY, CenterX, Radius };
                return new HTuple(circle);
            }
            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        /// <summary>
        /// 椭圆信息
        /// </summary>
        [Serializable]
        public class Ellipse_INFO : ROI, ICloneable
        {
            public double CenterY, CenterX, Phi, Radius1, Radius2;
            double StartPhi = 0.0, EndPhi = Math.PI * 2;
            public string PointOrder = "positive";
            public Ellipse_INFO()
            {
            }
            public Ellipse_INFO(double m_Row_center, double m_Column_center, double m_Phi, double m_Radius1, double m_Radius2)
            {
                this.CenterY = m_Row_center;
                this.CenterX = m_Column_center;
                this.Phi = m_Phi;
                this.Radius1 = m_Radius1;
                this.Radius2 = m_Radius2;
            }
            public override HRegion genRegion()
            {
                HRegion h = new HRegion();
                h.GenEllipse(CenterY, CenterX, Phi, Radius1, Radius2);
                return h;
            }

            public override HXLDCont genXLD()
            {
                HXLDCont xld = new HXLDCont();
                xld.GenEllipseContourXld(CenterY, CenterX, Phi, Radius1, Radius2, StartPhi, EndPhi, PointOrder, 1.0);
                return xld;
            }
            public object Clone()
            {
                return this.MemberwiseClone();
            }
            public override HTuple getTuple()
            {
                double[] ellipse = new double[] { CenterY, CenterX, Phi, Radius1, Radius2 };
                return new HTuple(ellipse);
            }
        }
        /// <summary>
        /// 矩形阵列返回的信息
        /// </summary>
        [Serializable]
        public struct RectRoiInfo
        {
            public bool Status;
            public double X;//mm坐标
            public double Y;//mm坐标
            public double Value_Avg;///均值
            public double Value_Median;///中指
            public double Value_Max;///最大值
            public double Value_Min;///最小值
            public List<double> X_List;//x mm坐标
            public List<double> Y_List;//y mm坐标
            public List<double> Value_List;

            public RectRoiInfo(double _x, double _y, double _avg, double _median, double _max, double _min, List<double> _xList, List<double> _yList, List<double> _valueList)
            {
                X = _x;
                Y = _y;
                Value_Avg = _avg;
                Value_Median = _median;
                Value_Max = _max;
                Value_Min = _min;
                X_List = _xList;
                Y_List = _yList;
                Value_List = _valueList;
                Status = true;
            }
        }


        /// <summary>
        /// 添加自定义形状
        /// </summary>
        [Serializable]
        public class UserDefinedShape_INFO : ROI
        {
            HRegion mHRegion;
            public UserDefinedShape_INFO()
            {
            }
            public UserDefinedShape_INFO(HRegion hregion)
            {
                mHRegion = hregion;
            }
            public override HRegion genRegion()
            {
                return mHRegion;
            }
            public override HXLDCont genXLD()
            {
                if (mHRegion != null && mHRegion.IsInitialized())
                {
                    return mHRegion.GenContourRegionXld("border_holes");
                }
                else
                {
                    return new HXLDCont();
                }
            }
            public override HTuple getTuple()
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 矩形信息
        /// </summary>
        [Serializable]
        public class Rectangle_INFO : ROI
        {
            public double StartY, StartX, EndY, EndX;
            public Rectangle_INFO()
            {

            }
            public Rectangle_INFO(double m_Row_Start, double m_Column_Start, double m_Row_End, double m_Column_End)
            {
                this.StartY = m_Row_Start;
                this.StartX = m_Column_Start;
                this.EndY = m_Row_End;
                this.EndX = m_Column_End;
            }
            public override HRegion genRegion()
            {
                HRegion h = new HRegion();
                h.GenRectangle1(StartY, StartX, EndY, EndX);
                return h;
            }
            public override HXLDCont genXLD()
            {
                HXLDCont xld = new HXLDCont();
                HTuple row = new HTuple(StartY, EndY, EndY, StartY, StartY);
                HTuple col = new HTuple(StartX, StartX, EndX, EndX, StartX);
                xld.GenContourPolygonXld(row, col);
                return xld;
            }

            public override HTuple getTuple()
            {
                double[] rect1 = new double[] { StartY, StartX, EndY, EndX };
                return new HTuple(rect1);
            }
        }

        /// <summary>
        /// 旋转矩形信息
        /// </summary>
        [Serializable]
        public class Rectangle2_INFO : ROI, ICloneable
        {
            public double CenterY;
            public double CenterX;
            public double Phi;
            public double Length1;
            public double Length2;
            /// <summary>
            /// 
            /// </summary>
            public Rectangle2_INFO()
            {
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="m_Row_center"></param>
            /// <param name="m_Column_center"></param>
            /// <param name="m_Phi"></param>
            /// <param name="m_Length1"></param>
            /// <param name="m_Length2"></param>
            public Rectangle2_INFO(double m_Row_center, double m_Column_center, double m_Phi, double m_Length1, double m_Length2)
            {
                this.CenterY = m_Row_center;
                this.CenterX = m_Column_center;
                this.Phi = m_Phi;
                this.Length1 = m_Length1;
                this.Length2 = m_Length2;
            }
            public override HRegion genRegion()
            {
                HRegion h = new HRegion();
                h.GenRectangle2(CenterY, CenterX, Phi, Length1, Length2);
                return h;
            }
            public override HXLDCont genXLD()
            {
                HXLDCont xld = new HXLDCont();
                xld.GenRectangle2ContourXld(CenterY, CenterX, Phi, Length1, Length2);
                return xld;
            }
            public override HTuple getTuple()
            {
                double[] rect2 = new double[] { CenterY, CenterX, Phi, Length1, Length2 };
                return new HTuple(rect2);
            }
            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        /// <summary>
        /// 3D点数据
        /// </summary>
        [Serializable]
        public struct Point3DF //3D点数据
        {
            public float X;
            public float Y;
            public float Z;
            public Point3DF(float _x, float _y, float _z)
            {
                this.X = _x;
                this.Y = _y;
                this.Z = _z;
            }
        }

        /// <summary>
        /// 矩形阵列返回的信息
        /// </summary>
        [Serializable]
        public struct RectInfo
        {
            public double X;//mm坐标
            public double Y;//mm坐标
            public double Value_Avg;///均值
            public double Value_Median;///中指
            public double Value_Max;///最大值
            public double Value_Min;///最小值
            public List<double> X_List;//x mm坐标
            public List<double> Y_List;//y mm坐标
            public List<double> Value_List;

            public RectInfo(double _x, double _y, double _avg, double _median, double _max, double _min, List<double> _xList, List<double> _yList, List<double> _valueList)
            {
                X = _x;
                Y = _y;
                Value_Avg = _avg;
                Value_Median = _median;
                Value_Max = _max;
                Value_Min = _min;
                X_List = _xList;
                Y_List = _yList;
                Value_List = _valueList;
            }
        }

        /// <summary>
        /// 十字坐标信息
        /// </summary>
        [Serializable]
        public struct Coordinate_INFO
        {
            public double Y, X, Phi;
            public Coordinate_INFO(double _row, double _col, double _phi)
            {
                this.Y = _row;
                this.X = _col;
                this.Phi = _phi;//坐标系X轴与图像X轴正方向的夹角
            }
        }

        /// <summary>
        /// 测量信息
        /// </summary>
        [Serializable]
        public struct Metrology_INFO
        {
            public double Length1, Length2, Threshold, MeasureDis;
            public HTuple ParamName, ParamValue;
            public int PointsOrder;

            public Metrology_INFO(double _length1, double _length2, double _threshold, double _measureDis, HTuple _paraName, HTuple _paraValue, int _pointsOrder)
            {
                this.Length1 = _length1;                        // 长/2
                this.Length2 = _length2;                        // 宽/2
                this.Threshold = _threshold;                    // 阈值
                this.MeasureDis = _measureDis;                  //间隔
                this.ParamName = _paraName;                     //参数名
                this.ParamValue = _paraValue;                   //参数值
                this.PointsOrder = _pointsOrder;                //点顺序 0位默认，1 顺时针，2 逆时针
            }
        }

    }

    [Serializable]
    public class ROILine : ROI2, ICloneable
    {
        public bool Status;
        /// <summary>起点行坐标</summary>
        public double StartX;
        /// <summary>起点列坐标</summary>
        public double StartY;
        /// <summary>终点行坐标</summary>
        public double EndX;
        /// <summary>终点列坐标</summary>
        public double EndY;
        /// <summary>中点行坐标</summary>
        public double MidX;
        /// <summary>中点列坐标</summary>
        public double MidY;
        /// <summary>直线角度</summary>
        public double Phi;
        /// <summary>直线长度</summary>
        public double Dist;
        /// <summary>行向量</summary>
        public double Nx;
        /// <summary>列向量</summary>
        public double Ny;
        /// <summary>X点集合</summary>
        public double[] X;
        /// <summary>Y点集合</summary>
        public double[] Y;
        /// <summary>直线上添加箭头显示</summary>
        private HObject arrowHandleXLD;
        public ROILine()
        {
            NumHandles = 3;        // two end points of line
            ActiveHandleId = 2;
            Status = true;
        }

        public ROILine(double beginRow, double beginCol, double endRow, double endCol)
        {
            CreateLine(beginRow, beginCol, endRow, endCol);
        }

        public  void CreateLine(double beginRow, double beginCol, double endRow, double endCol)
        {
            //base.CreateLine(beginRow, beginCol, endRow, endCol);

            StartX = beginRow;
            StartY = beginCol;
            EndX = endRow;
            EndY = endCol;
            Ny = StartX - EndX;
            Nx = EndY - StartY;
            MidX = (StartX + EndX) / 2.0;
            MidY = (StartY + EndY) / 2.0;
            Phi = HMisc.AngleLx(StartY, StartX, EndY, EndX);
            ShowArrowHandle();
            Status = true;
        }

        /// <summary>Creates a new ROI instance at the mouse position.</summary>
        public  void CreateROI(double midX, double midY)
        {
            MidX = midY;
            MidY = midX;

            StartX = MidX;
            StartY = MidY - 50;
            EndX = MidX;
            EndY = MidY + 50;

            Ny = StartX - EndX;
            Nx = EndY - StartY;

            ShowArrowHandle();
        }
        /// <summary>Paints the ROI into the supplied window.</summary>
        public  void Draw(HWindow window)
        {

            window.DispLine(StartX, StartY, EndX, EndY);

            window.DispRectangle2(StartX, StartY, 0, 3, 3);
            window.DispObj(arrowHandleXLD);  //window.DispRectangle2( EndX, EndY, 0, 25, 25);
            window.DispRectangle2(MidX, MidY, 0, 3, 3);
            Phi = HMisc.AngleLx(StartY, StartX, EndY, EndX);
        }

        /// <summary> 
        /// Returns the distance of the ROI handle being
        /// closest to the image point(x,y).
        /// </summary>
        public  double DistToClosestHandle(double x, double y)
        {

            double max = 10000;
            double[] val = new double[NumHandles];

            val[0] = HMisc.DistancePp(y, x, StartX, StartY); // upper left 
            val[1] = HMisc.DistancePp(y, x, EndX, EndY); // upper right 
            val[2] = HMisc.DistancePp(y, x, MidX, MidY); // midpoint 

            for (int i = 0; i < NumHandles; i++)
            {
                if (val[i] < max)
                {
                    max = val[i];
                    ActiveHandleId = i;
                }
            }// end of for 

            return val[ActiveHandleId];
        }

        /// <summary> 
        /// Paints the active handle of the ROI object into the supplied window. 
        /// </summary>
        public  void DisplayActive(HWindow window)
        {

            switch (ActiveHandleId)
            {
                case 0:
                    window.DispRectangle2(StartX, StartY, 0, 3, 3);
                    break;
                case 1:
                    window.DispObj(arrowHandleXLD); //window.DispRectangle2(EndX, EndY, 0, 25, 25);
                    break;
                case 2:
                    window.DispRectangle2(MidX, MidY, 0, 3, 3);
                    break;
            }
        }

        /// <summary>Gets the HALCON region described by the ROI.</summary>
        public  HRegion GetRegion()
        {
            HRegion region = new HRegion();
            region.GenRegionLine(StartX, StartY, EndX, EndY);
            return region;
        }
        public  HXLDCont GetXLD()
        {
            HXLDCont xld = null;
            try
            {
                HOperatorSet.GenContourPolygonXld(out HObject m_ResultXLD, new HTuple(StartY, EndY), new HTuple(StartX, EndX));
                xld = new HXLDCont(m_ResultXLD);
                return xld;
            }
            catch { }
            return xld;
        }
        public  double GetDistanceFromStartPoint(double row, double col)
        {
            double distance = HMisc.DistancePp(row, col, StartX, StartY);
            return distance;
        }
        /// <summary>
        /// Gets the model information described by 
        /// the ROI.
        /// </summary> 
        public override HTuple GetModelData()
        {
            return new HTuple(new double[] { StartX, StartY, EndX, EndY });
        }

        /// <summary> 
        /// Recalculates the shape of the ROI. Translation is 
        /// performed at the active handle of the ROI object 
        /// for the image coordinate (x,y).
        /// </summary>
        public  void moveByHandle(double newX, double newY)
        {
            double lenR, lenC;

            switch (ActiveHandleId)
            {
                case 0: // first end point
                    StartX = newY;
                    StartY = newX;

                    MidX = (StartX + EndX) / 2;
                    MidY = (StartY + EndY) / 2;
                    break;
                case 1: // last end point
                    EndX = newY;
                    EndY = newX;

                    MidX = (StartX + EndX) / 2;
                    MidY = (StartY + EndY) / 2;
                    break;
                case 2: // midpoint 
                    lenR = StartX - MidX;
                    lenC = StartY - MidY;

                    MidX = newY;
                    MidY = newX;

                    StartX = MidX + lenR;
                    StartY = MidY + lenC;
                    EndX = MidX - lenR;
                    EndY = MidY - lenC;
                    break;
            }
            ShowArrowHandle();
        }

        /// <summary>
        /// Auxiliary method
        /// </summary>
        private void ShowArrowHandle()
        {
            double length, dr, dc, halfHW;
            double rrow1, ccol1, rowP1, colP1, rowP2, colP2;

            double headLength = 15;
            double headWidth = 15;
            arrowHandleXLD = new HXLDCont();
            arrowHandleXLD.GenEmptyObj();

            arrowHandleXLD.Dispose();
            arrowHandleXLD.GenEmptyObj();

            rrow1 = StartX + (EndX - StartX) * 0.9;
            ccol1 = StartY + (EndY - StartY) * 0.9;

            length = HMisc.DistancePp(rrow1, ccol1, EndX, EndY);
            if (length == 0)
                length = -1;

            dr = (EndX - rrow1) / length;
            dc = (EndY - ccol1) / length;

            halfHW = headWidth / 2;
            rowP1 = (rrow1 + (length - headLength) * dr + halfHW * dc);
            colP1 = (ccol1 + (length - headLength) * dc - halfHW * dr);
            rowP2 = (rrow1 + (length - headLength) * dr - halfHW * dc);
            colP2 = (ccol1 + (length - headLength) * dc + halfHW * dr);
            Phi = HMisc.AngleLx(StartY, StartX, EndY, EndX);
            if (length == -1)
                HOperatorSet.GenContourPolygonXld(out arrowHandleXLD, rrow1, ccol1);
            else
                HOperatorSet.GenContourPolygonXld(out arrowHandleXLD, new HTuple(new double[] { rrow1, EndX, rowP1, EndX, rowP2, EndX }),
                                                    new HTuple(new double[] { ccol1, EndY, colP1, EndY, colP2, EndY }));
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }//end of class

    [Serializable]
    public class RImage : HImage, ISerializable
    {
        /// <summary>状态</summary>
        public bool Status = true;
        /// <summary> 名称 </summary>
        public string Name = string.Empty;
        /// <summary>窗体索引</summary>
        public int Screen = 0;
        /// <summary>宽</summary>
        public int Width = 0;
        /// <summary>高</summary>
        public int Height = 0;
        /// <summary>采集当前图像时候的位置X </summary>
        public double X = 0;
        /// <summary> 采集当前图像时候的位置X</summary>
        public double Y = 0;
        /// <summary>采集当前图像时候的位置X</summary>
        public double Z = 0;
        /// <summary> X轴和直角坐标系X轴夹角 </summary>
        public double PhiX = 0;
        /// <summary> X轴和直角坐标系旋转重叠后 Y轴和直角坐标系Y轴夹角 </summary>
        public double PhiY = 0;
        /// <summary> X方向像素比率</summary>
        public double ScaleX = 1;
        /// <summary> Y方向像素比率</summary>
        public double ScaleY = 1;
        #region 区域标定映射
        /// <summary> 标定板行坐标</summary>
        public HTuple BoardRow { get; set; }
        /// <summary> 标定板列坐标 </summary>
        public HTuple BoardCol { get; set; }
        /// <summary>标定板X坐标 </summary>
        public HTuple BoardX { get; set; }
        /// <summary> 标定板列坐标</summary>
        public HTuple BoardY { get; set; }
        /// <summary> 标定标记</summary>
        public bool IsCal { get; set; }
        #endregion
        #region 构造函数
        /// <summary> 构造函数 </summary>
        public RImage() : base() { }
        /// <summary> 构造函数 </summary>
        /// <param name="obj"></param>
        public RImage(HObject obj) : base(obj) { }
        /// <summary>构造函数</summary>
        /// <param name="fileName"></param>
        public RImage(string fileName) : base(fileName) { }
        /// <summary>构造函数 </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public RImage(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            this.X = info.GetDouble("X");
            this.Y = info.GetDouble("Y");
            this.Z = info.GetDouble("Z");
            this.PhiX = info.GetDouble("PhiX");
            this.PhiY = info.GetDouble("PhiY");
            this.ScaleX = info.GetDouble("ScaleX");
            this.ScaleY = info.GetDouble("ScaleY");
            this.Status = info.GetBoolean("Status");
            try
            {
                this.mHRoi = (List<HRoi>)info.GetValue("mHRoi", typeof(List<HRoi>));
                this.mHText = (List<HText>)info.GetValue("mHText", typeof(List<HText>));
            }
            catch (Exception ex) { }//Log.Error(ex.ToString()); }
        }
        ///<summary>序列化</summary>
        ///<param name="info"></param>
        ///<param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            try
            {
                if (info == null)
                {
                    throw new System.ArgumentNullException("info");
                }
                info.AddValue("X", X);
                info.AddValue("Y", Y);
                info.AddValue("Z", Z);
                info.AddValue("PhiX", PhiX);
                info.AddValue("PhiY", PhiY);
                info.AddValue("ScaleX", ScaleX);
                info.AddValue("ScaleY", ScaleY);
                info.AddValue("Status", Status);
                info.AddValue("mHRoi", mHRoi);
                info.AddValue("mHText", mHText);
                HSerializedItem item = this.SerializeImage();//Himage 内部函数 反编译得到的
                byte[] buffer = item;
                item.Dispose();
                info.AddValue("data", buffer, typeof(byte[]));
            }
            catch (Exception ex) { }//Log.Error(ex.ToString()); }
        }
        #endregion
        /// <summary>图片缩放</summary>
        public HHomMat2D GetHome()
        {
            HHomMat2D hom = new HHomMat2D();
            hom = hom.HomMat2dScaleLocal(ScaleX, ScaleY);
            return hom;
        }
        /// <summary> 获取校正相机夹角和校正轴矩阵</summary>
        public HHomMat2D GetAngle()
        {
            HHomMat2D homA = new HHomMat2D();
            homA = homA.HomMat2dRotateLocal(PhiX);//校正相机和轴夹角
                                                  //homA = homA.HomMat2dSlantLocal(Y * Math.Sin(PhiY), "x");//校正XY轴夹角
            return homA;
        }
        /// <summary>保存RImage</summary>
        public void SaveRImage(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            if (ext == ".he")
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    BinaryFormatter binaryFmt = new BinaryFormatter();
                    fs.Seek(0, SeekOrigin.Begin);
                    binaryFmt.Serialize(fs, this);
                }
            }
            else if (ext == "") //当没有传入有后缀的fileName,默认保存png magical 20170822
            {
                if (GetImageType().ToString().Contains("real"))
                {
                    this.WriteImage("tiff", 0, fileName);
                }
                else
                {
                    this.WriteImage("png best", 0, fileName);
                }
            }
            else
            {
                this.WriteImage(ext.Substring(1), 0, fileName);
            }
        }
        /// <summary>HImageToRImage</summary>
        public static RImage ToRImage(HObject image)
        {
            return new RImage(image);
        }
        /// <summary> 从文件中获取RImage对象</summary>
        public static RImage ReadRImage(string fileName)
        {
            RImage ImgExt = null;
            try
            {
                if (Path.GetExtension(fileName).ToLower() == ".he")
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.Open))//作为语句：用于定义一个范围，在此范围的末尾将释放对象。 请参阅 using 语句。 by:longteng
                    {
                        fs.Seek(0, SeekOrigin.Begin);
                        BinaryFormatter binaryFmt = new BinaryFormatter();
                        ImgExt = (RImage)binaryFmt.Deserialize(fs);
                    }
                }
                else
                {
                    ImgExt = ToRImage(new HImage(fileName));
                    ImgExt.Name = Path.GetFileName(fileName);

                }
                GC.Collect();
                return ImgExt;
            }
            catch (Exception ex)
            {
                //Log.Error(ex.ToString());
                return ImgExt;
            }
        }

        /// <summary>显示的ROI</summary>
        public List<HRoi> mHRoi = new List<HRoi>();
        /// <summary>显示的信息</summary>
        public List<HText> mHText = new List<HText>();
        /// <summary>显示Roi</summary>
        public void ShowHRoi(HRoi ROI)
        {
            try
            {
                int index = mHRoi.FindIndex(e => e.CellID == ROI.CellID && e.roiType == ROI.roiType && e.CellType == ROI.CellType);
                if (ROI.fors == true)
                {
                    mHRoi.Add(ROI);
                    return;
                }
                if (index > -1)
                    mHRoi[index] = ROI;
                else
                    mHRoi.Add(ROI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        /// <summary>显示文本 </summary>
        public void ShowHText(HText ROI)
        {
            try
            {
                int index = mHText.FindIndex(e => e.CellType == ROI.CellType && e.roiType == ROI.roiType && e.CellType == ROI.CellType);
                if (ROI.fors == true)
                {
                    mHText.Add(ROI);
                    return;
                }
                if (index > -1)
                    mHText[index] = ROI;
                else
                    mHText.Add(ROI);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        /// <summary>深拷贝</summary>
        public new RImage Clone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                mHRoi = mHRoi.Where(c => c != null && (c.hobject == null || c.hobject.IsInitialized())).ToList();
                mHText = mHText.Where(c => c != null && (c.hobject == null || c.hobject.IsInitialized())).ToList();
                formatter.Serialize(stream, this);
                stream.Position = 0;
                return formatter.Deserialize(stream) as RImage;
            }
        }
        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            foreach (HRoi ROI in mHRoi)
            {
                if (ROI.hobject == null || !ROI.hobject.IsInitialized())//修复为null 错误 magical 20171103
                {
                    ROI.hobject = null;
                }
            }
            foreach (HText ROI in mHText)
            {
                if (ROI.hobject == null || !ROI.hobject.IsInitialized())//修复为null 错误 magical 20171103
                {
                    ROI.hobject = null;
                }
            }
        }
        [OnDeserialized()]
        internal void OnDeSerializedMethod(StreamingContext context)
        {
            //如果he为老版本没有x y比例 手动设置为1,否则离线读取数据计算时候会出现异常   yoga 20180824
            if (ScaleX == 0)
            {
                ScaleX = 1;
            }
            if (ScaleY == 0)
            {
                ScaleY = 1;
            }
        }
    }

    [Serializable]
    public class ROICircle : ROI2
    {
        public bool Status;
        public string PointOrder = "positive";
        public double Radius;
        public double StartPhi, EndPhi;  // first handle
        public double CenterX, CenterY;  // second handle
        public ROICircle()
        {
            NumHandles = 2; // one at corner of circle + midpoint
            ActiveHandleId = 1;
            Status = true;
        }
        public string GetName()
        {
            return "";
        }
        public ROICircle(double row, double col, double Radius)
        {
            CreateCircle(row, col, Radius);
        }
        public  void CreateCircle(double row, double col, double Radius)
        {
            base.CreateCircle(row, col, Radius);
            CenterX = row;
            CenterY = col;

            this.Radius = Radius;

            StartPhi = CenterX;
            EndPhi = CenterY + Radius;
            Status = true;
        }
        /// <summary>Creates a new ROI instance at the mouse position</summary>
        public  void CreateROI(double midX, double midY)
        {
            CenterX = midY;
            CenterY = midX;

            Radius = 100;

            StartPhi = CenterX;
            EndPhi = CenterY + Radius;
        }
        /// <summary>Paints the ROI into the supplied window</summary>
        /// <param name="window">HALCON window</param>
        public  void Draw(HWindow window)
        {
            window.DispCircle(CenterX, CenterY, Radius);
            window.DispRectangle2(StartPhi, EndPhi, 0, 3, 3);
            window.DispRectangle2(CenterX, CenterY, 0, 3, 3);
        }
        /// <summary> 
        /// Returns the distance of the ROI handle being
        /// closest to the image point(x,y)
        /// </summary>
        public  double DistToClosestHandle(double x, double y)
        {
            double max = 10000;
            double[] val = new double[NumHandles];

            val[0] = HMisc.DistancePp(y, x, StartPhi, EndPhi); // border handle 
            val[1] = HMisc.DistancePp(y, x, CenterX, CenterY); // midpoint 

            for (int i = 0; i < NumHandles; i++)
            {
                if (val[i] < max)
                {
                    max = val[i];
                    ActiveHandleId = i;
                }
            }// end of for 
            return val[ActiveHandleId];
        }
        /// <summary> 
        /// Paints the active handle of the ROI object into the supplied window 
        /// </summary>
        public  void DisplayActive(HWindow window)
        {

            switch (ActiveHandleId)
            {
                case 0:
                    window.DispRectangle2(StartPhi, EndPhi, 0, 3, 3);
                    break;
                case 1:
                    window.DispRectangle2(CenterX, CenterY, 0, 3, 3);
                    break;
            }
        }
        /// <summary>Gets the HALCON region described by the ROI</summary>
        public  HRegion GetRegion()
        {
            HRegion region = new HRegion();
            region.GenCircle(CenterX, CenterY, Radius);
            return region;
        }
        public  HXLDCont GetXLD()
        {
            HXLDCont xld = new HXLDCont();
            xld.GenCircleContourXld(CenterY, CenterX, Radius, StartPhi, EndPhi, PointOrder, 1.0);
            return xld;
        }
        public  double GetDistanceFromStartPoint(double row, double col)
        {
            double sRow = CenterX; // assumption: we have an angle starting at 0.0
            double sCol = CenterY + 1 * Radius;

            double angle = HMisc.AngleLl(CenterX, CenterY, sRow, sCol, CenterX, CenterY, row, col);

            if (angle < 0)
                angle += 2 * Math.PI;

            return (Radius * angle);
        }
        /// <summary>
        /// Gets the model information described by 
        /// the  ROI
        /// </summary> 
        public  HTuple GetModelData()
        {
            return new HTuple(new double[] { CenterX, CenterY, Radius });
        }
        /// <summary> 
        /// Recalculates the shape of the ROI. Translation is 
        /// performed at the active handle of the ROI object 
        /// for the image coordinate (x,y)
        /// </summary>
        public void moveByHandle(double newX, double newY)
        {
            HTuple distance;
            double shiftX, shiftY;

            switch (ActiveHandleId)
            {
                case 0: // handle at circle border

                    StartPhi = newY;
                    EndPhi = newX;
                    HOperatorSet.DistancePp(new HTuple(StartPhi), new HTuple(EndPhi),
                                            new HTuple(CenterX), new HTuple(CenterY),
                                            out distance);

                    Radius = distance[0].D;
                    break;
                case 1: // midpoint 

                    shiftY = CenterX - newY;
                    shiftX = CenterY - newX;

                    CenterX = newY;
                    CenterY = newX;

                    StartPhi -= shiftY;
                    EndPhi -= shiftX;
                    break;
            }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }//end of class
    /// <summary>内部常量定义</summary>
    public static class ConstVar
    {
        #region 单元输出变量 定义和赋值不允许重复
        //图像输出
        public const string Image = "Image";
        public const string ScaleX = "ScaleX";
        public const string ScaleY = "ScaleY";
        public const string Coord = "Coord";
        public const string PointF = "PointF";
        public const string HomMat2D = "HomMat2D";
        public const string Corde2D = "Corde2D";
        public const string BarCorde = "BarCorde";
        public const string ROI = "ROI";
        public const string Result = "Result";
        public const string Rect_Info = "Rect_Info";
        public const string X = "X";
        public const string Y = "Y";
        public const string Row = "Row";
        public const string Col = "Col";
        public const string Row1 = "Row1";
        public const string Col1 = "Col1";
        public const string StartX = "StartX";
        public const string StartY = "StartY";
        public const string EndX = "EndX";
        public const string EndY = "EndY";
        public const string Phi = "Phi";
        public const string MidX = "MidX";
        public const string MidY = "MidY";
        public const string Radius = "Radius";
        public const string Line = "Line";
        public const string Circle = "Circle";
        public const string CircleArr = "CircleArr";
        public const string Ellipse = "Ellipse";
        public const string Rectangle1 = "Rectangle1";
        public const string Rectangle2 = "Rectangle2";
        public const string LineRow = "LineRow";
        public const string LineCol = "LineCol";
        public const string CircleRow = "CircleRow";
        public const string CircleCol = "CircleCol";
        public const string EllipseRow = "EllipseRow";
        public const string EllipseCol = "EllipseCol";
        public const string Flatness1 = "Flatness1";
        public const string Flatness2 = "Flatness2";

        #endregion
    }

    /// <summary>
    /// 用于展示效果的HObject
    /// </summary>
    [Serializable]
    public class HRoi
    {
        /// <summary>
        /// 单元id
        /// </summary>
        public int CellID { get; set; }
        /// <summary>
        /// 单元类型
        /// </summary>
        public string CellType { get; set; }
        /// <summary>
        /// 单元描述
        /// </summary>
        public string CellNote { get; set; }
        /// <summary>
        /// 轮廓分类
        /// </summary>
        public HRoiType roiType { get; set; }
        /// <summary>
        /// 画笔颜色
        /// </summary>
        public string drawColor { get; set; }
        /// <summary>
        /// 测量roi
        /// </summary>
        public HObject hobject { get; set; }
        /// <summary>
        /// 循环+
        /// </summary>
        public bool fors { get; set; }
        /// <summary>
        /// 测量roi
        /// </summary>
        public HRoi() { }
        /// <summary>
        /// 测量roi
        /// </summary>
        /// <param name="_CellID">单元id</param>
        /// <param name="_CellType">单元类型</param>
        /// <param name="_CellNote">单元描述</param>
        /// <param name="_drawColor">画笔颜色</param>
        /// <param name="_hobject">测量roi 必须为HObject类型</param>
        public HRoi(int _CellID, string _CellType, string _CellNote, HRoiType _roiType, string _drawColor, HObject _hobject)
        {
            CellID = _CellID;
            CellType = _CellType;
            CellNote = _CellNote;
            roiType = _roiType;
            drawColor = _drawColor;
            hobject = _hobject;
        }
        /// <summary>
        /// 测量roi
        /// </summary>
        /// <param name="_CellID">单元id</param>
        /// <param name="_CellType">单元类型</param>
        /// <param name="_CellNote">单元描述</param>
        /// <param name="_roiType">Roi类型</param>
        /// <param name="_drawColor">画笔颜色</param>
        /// <param name="_hobject">测量roi 必须为HObject类型</param>
        /// <param name="_for">是否循环+</param>
        public HRoi(int _CellID, string _CellType, string _CellNote, HRoiType _roiType, string _drawColor, HObject _hobject, bool _for)
        {
            CellID = _CellID;
            CellType = _CellType;
            CellNote = _CellNote;
            roiType = _roiType;
            drawColor = _drawColor;
            hobject = _hobject;
            fors = _for;
        }
        /// <summary>
        /// 测量roi
        /// </summary>
        /// <param name="_CellID">单元id</param>
        /// <param name="_CellType">单元类型</param>
        /// <param name="_CellNote">单元描述</param>
        /// <param name="_drawColor">画笔颜色</param>
        /// <param name="_hobject">测量roi 必须为HObject类型</param>
        public HRoi(int _CellID, string _CellType, string _CellNote, HRoiType _roiType, string _drawColor, HObject[] _hobject)
        {
            int i = 0;
            CellID = _CellID;
            CellType = _CellType;
            CellNote = _CellNote;
            roiType = _roiType;
            drawColor = _drawColor;
            hobject = _hobject[i];
        }
        /// <summary>
        /// 轮廓分类
        /// </summary>    
        public enum HRoiType
        {
            检测点,
            检测X点,
            检测Y点,
            检测点P1,
            检测点P2,
            检测范围,
            检测中心,
            检测结果,
            搜索范围,
            搜索方向,
            屏蔽范围,
            文字显示,
            参考坐标,
        }

        [OnSerializing]
        internal void OnSerializingMethod(StreamingContext context)
        {
            if (hobject != null && !hobject.IsInitialized())//修复为null 错误 magical 20171103
            {
                hobject = null;
            }
        }
    }

    [Serializable]
    public class HText : HRoi
    {
        /// <summary>
        /// 文字
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 字体
        /// </summary>
        public string font = "mono";
        /// <summary>
        /// 显示的位置-X
        /// </summary>
        public double row { get; set; }
        /// <summary>
        /// 显示的位置-Y
        /// </summary>
        public double col { get; set; }
        /// <summary>
        /// 大小
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// 角度
        /// </summary>
        public int phi { get; set; }
        /// <summary>
        /// 测量roi
        /// </summary>
        /// <param name="_CellID">单元id</param>
        /// <param name="_CellType">单元类型</param>
        /// <param name="_CellNote">单元描述</param>
        /// <param name="_roiType">ROI类型</param>
        /// <param name="_drawColor">画笔颜色</param>
        /// <param name="_text">文本内容</param>
        /// <param name="_font">字体</param>
        /// <param name="_row">行</param>
        /// <param name="_col">列</param>
        /// <param name="_size">大小</param>
        /// <param name="_hobject">测量roi 必须为HObject类型</param>
        public HText(int _CellID, string _CellType, string _CellNote, HRoiType _roiType, string _drawColor, string _text, string _font, double _row, double _col, int _size, HObject _hobject)
        {
            CellID = _CellID;
            CellType = _CellType;
            CellNote = _CellNote;
            roiType = _roiType;
            drawColor = _drawColor;
            text = _text;
            font = _font;
            row = _row;
            col = _col;
            size = _size;
            hobject = _hobject;
        }
        /// <summary>
        /// 测量roi
        /// </summary>
        /// <param name="_CellID">单元id</param>
        /// <param name="_CellType">单元类型</param>
        /// <param name="_CellNote">单元描述</param>
        /// <param name="_roiType">ROI类型</param>
        /// <param name="_drawColor">画笔颜色</param>
        /// <param name="_text">文本内容</param>
        /// <param name="_font">字体</param>
        /// <param name="_row">行</param>
        /// <param name="_col">列</param>
        /// <param name="_size">大小</param>
        /// <param name="_hobject">测量roi 必须为HObject类型</param>
        /// <param name="_size">循环+</param>
       public HText(int _CellID, string _CellType, string _CellNote, HRoiType _roiType, string _drawColor, string _text, string _font, double _row, double _col, int _size, HObject _hobject, bool _for)
        {
            CellID = _CellID;
            CellType = _CellType;
            CellNote = _CellNote;
            roiType = _roiType;
            drawColor = _drawColor;
            text = _text;
            font = _font;
            row = _row;
            col = _col;
            size = _size;
            hobject = _hobject;
            fors = _for;
        }
    }

    /// <summary>
    /// 标定信息
    /// </summary>
    [Serializable]
    public struct Cal_Info
    {
        public bool Status;
        /// <summary>平移X</summary>
        public double ParallelX;
        /// <summary>平移Y</summary>
        public double ParallelY;
        /// <summary>像素当量X</summary>
        public double PixelX;
        /// <summary>像素当量Y</summary>
        public double PixelY;
        /// <summary>旋转角度</summary>
        public double RotationAngle;
        /// <summary>倾斜角度</summary>
        public double TiltAngle;
        /// <summary>RMS平分</summary>
        public double RMS;
        /// <summary>旋转中心X</summary>
        public double RrotationCenterX;
        /// <summary>旋转中心Y</summary>
        public double RrotationCenterY;
        /// <summary>旋转启用</summary>
        public bool RotatingEnabled;
        /// <summary>方向一致</summary>
        public bool SameDirection;
        /// <summary>相机固定</summary>
        public bool CameraFix;
        /// <summary>MarkX</summary>
        public double MarkX;
        /// <summary>MarkY</summary>
        public double MarkY;
        /// <summary>基准X</summary>
        public double BaselineX;
        /// <summary>基准Y</summary>
        public double BaselineY;
        /// <summary>基准角度</summary>
        public double BaselineAngel;
        public string GetName()
        {
            return "ParallelX";
        }
        /// <summary>
        /// 标定信息
        /// </summary>
        /// <param name="_ParallelX">平移X</param>
        /// <param name="_ParallelY">平移Y</param>
        /// <param name="_PixelX">像素当量X</param>
        /// <param name="_PixelY">像素当量Y</param>
        /// <param name="_RotationAngle">旋转角度</param>
        /// <param name="_TiltAngle">倾斜角度</param>
        /// <param name="_RMS">RMS平分</param>
        /// <param name="_RrotationCenterX">旋转中心X</param>
        /// <param name="_RrotationCenterY">旋转中心Y</param>
        /// <param name="_RotatingEnabled">旋转启用</param>
        /// <param name="_SameDirection">方向一致</param>
        public Cal_Info(double _ParallelX, double _ParallelY, double _PixelX, double _PixelY, double _RotationAngle, double _TiltAngle, double _RMS, double _RrotationCenterX, double _RrotationCenterY, bool _RotatingEnabled, bool _SameDirection,
            bool _CameraFix, double _MarkX, double _MarkY, double _BaselineX, double _BaselineY, double _BaselineAngel)
        {
            ParallelX = _ParallelX;
            ParallelY = _ParallelY;
            PixelX = _PixelX;
            PixelY = _PixelY;
            RotationAngle = _RotationAngle;
            TiltAngle = _TiltAngle;
            RMS = _RMS;
            RrotationCenterX = _RrotationCenterX;
            RrotationCenterY = _RrotationCenterY;
            RotatingEnabled = _RotatingEnabled;
            SameDirection = _SameDirection;
            CameraFix = _CameraFix;
            MarkX = _MarkX;
            MarkY = _MarkY;
            BaselineX = _BaselineX;
            BaselineY = _BaselineY;
            BaselineAngel = _BaselineAngel;
            Status = true;
        }

        /// <summary>
        /// 返回信息- 
        /// </summary>
        [Serializable]
        public class Rtn_Info
        {
            public bool Status;
            /// <summary>值</summary>
            public string Value;
            public Rtn_Info() { }
            public Rtn_Info(string _Value)
            {
                Value = _Value;
                Status = true;
            }
        }

        /// <summary>
        /// 十字坐标信息
        /// </summary>
        [Serializable]
        public struct Coord_Info
        {
            public bool Status;
            public double Y, X, Phi;
            public Coord_Info(double _row, double _col, double _phi)
            {
                Y = _row;
                X = _col;
                Phi = _phi;//坐标系X轴与图像X轴正方向的夹角
                Status = true;
            }
        }
    }
    /// <summary>
    /// 返回信息- 
    /// </summary>
    [Serializable]
    public class Rtn_Info
    {
        public bool Status;
        /// <summary>值</summary>
        public string Value;
        public Rtn_Info() { }
        public Rtn_Info(string _Value)
        {
            Value = _Value;
            Status = true;
        }
    }
    [Serializable]
    public class RPoint
    {
        public double X;
        public double Y;
        public double[] X1;
        public double[] Y1;
        public RPoint() { }
        public RPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public RPoint(double[] x, double[] y)
        {
            this.X1 = x;
            this.Y1 = y;
        }
        /// <summary>重写点</summary>
        public static RPoint operator -(RPoint p1, RPoint p2)
        {
            return new RPoint(p1.X - p2.X, p1.Y - p2.Y);
        }
        /// <summary>获得点矢量长度</summary>
        public double GetDistance
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            }
        }
        public string ToShowTip()
        {
            return X.ToString() + " | " + Y.ToString();
        }
    }
    /// <summary>
    /// 十字坐标信息
    /// </summary>
    [Serializable]
    public struct Coord_Info
    {
        public bool Status;
        public double Y, X, Phi;
        public Coord_Info(double _row, double _col, double _phi)
        {
            Y = _row;
            X = _col;
            Phi = _phi;//坐标系X轴与图像X轴正方向的夹角
            Status = true;
        }
    }
    /// <summary>
    /// 测量信息- 长/2,宽/2,阈值,间隔,参数名,参数值,点顺序 (0位默认，1 顺时针，2 逆时针)
    /// </summary>
    [Serializable]
    public struct Meas_Info
    {
        /// <summary>长/2</summary>
        public double Length1;
        /// <summary>宽/2</summary>
        public double Length2;
        /// <summary>阈值</summary>
        public double Threshold;
        /// <summary>间隔</summary>
        public double MeasDis;
        /// <summary>参数名</summary>
        public HTuple ParamName;
        /// <summary>参数值</summary>
        public HTuple ParamValue;
        /// <summary>点顺序 0位默认,1顺时针,2逆时针</summary>
        public int PointsOrder;
        public Meas_Info(double _length1, double _length2, double _threshold, double _MeasDis, HTuple _paraName, HTuple _paraValue, int _pointsOrder)
        {
            Length1 = _length1;
            Length2 = _length2;
            Threshold = _threshold;
            MeasDis = _MeasDis;
            ParamName = _paraName;
            ParamValue = _paraValue;
            PointsOrder = _pointsOrder;
        }
    }

    /// <summary>拟合构建</summary>
    
    public class Fit
    {
        /// <summary>
        /// 用最小二乘法拟合平面
        /// </summary>
        /// <param name="lstX">x坐标序列点</param>
        /// <param name="lstY">y坐标序列点</param>
        /// <param name="lstZ">z坐标序列点</param>
        /// <returns>结果平面</returns>
        public static Plane_INFO FitPlane(List<double> lstX, List<double> lstY, List<double> lstZ)
        {
            Plane_INFO Plane = new Plane_INFO();
            try
            {
                if (lstX.Count != lstY.Count && lstY.Count != lstZ.Count && lstZ.Count < 3)
                    return Plane;
                int n = lstZ.Count;
                double x, y, z, XY, XZ, YZ;
                double X2, Y2;
                double a, b, c, d;
                double a1, b1, z1;
                double a2, b2, z2;
                tagVector n1;     //{.ax,by,1}  s1
                tagVector n2;     //{0,0,N} XY plane  s2
                tagVector n3;     //line Projed plane
                tagVector xLine, yLine, zLine, SLine;
                tagVector VectorPlane;
                xLine.a = 1;
                xLine.b = 0;
                xLine.c = 0;

                yLine.a = 0;
                yLine.b = 1;
                yLine.c = 0;

                zLine.a = 0;
                zLine.b = 0;
                zLine.c = 1;

                x = y = z = 0;
                XY = XZ = YZ = 0;
                X2 = Y2 = 0;

                for (int i = 0; i < n; i++)
                {
                    x += lstX[i];
                    y += lstY[i];
                    z += lstZ[i];

                    XY += lstX[i] * lstY[i];
                    XZ += lstX[i] * lstZ[i];
                    YZ += lstY[i] * lstZ[i];
                    X2 += lstX[i] * lstX[i];
                    Y2 += lstY[i] * lstY[i];
                }
                z1 = n * XZ - x * z;//              'e=z-Ax-By-C  z=Ax+By+D
                a1 = n * X2 - x * x;//
                b1 = n * XY - x * y;
                z2 = n * YZ - y * z;
                a2 = n * XY - x * y;
                b2 = n * Y2 - y * y;
                a = (z1 * b2 - z2 * b1) / (a1 * b2 - a2 * b1);
                b = (a1 * z2 - a2 * z1) / (a1 * b2 - a2 * b1);
                c = 1;
                d = (z - a * x - b * y) / n;


                Plane.x = x / n;
                Plane.y = y / n;
                Plane.z = z / n;
                //'sum(Mi *Ri)/sum(Mi) ,Mi is mass . here  Mi is seted to be 1 and .z is just the average of z
                Plane.ax = -a;
                Plane.by = -b;
                Plane.cz = 1;
                Plane.d = -d; //z=Ax+By+D-----Ax+By+Z+D=0

                VectorPlane.a = Plane.ax;
                VectorPlane.b = Plane.by;
                VectorPlane.c = 1;

                Plane.xAn =HMeasureSet.Intersect(VectorPlane, xLine);
                Plane.yAn = HMeasureSet.Intersect(VectorPlane, yLine);
                Plane.zAn = HMeasureSet.Intersect(VectorPlane, zLine);

                n1.a = Plane.ax;
                n1.b = Plane.by;
                n1.c = 1;

                SLine.a = Plane.ax;
                SLine.b = Plane.by;
                SLine.c = 0;

                Plane.Angle = HMeasureSet.Intersect(xLine, SLine);// (xLine.A * SLine.A + xLine.A * SLine.B + xLine.C * SLine.C)
                                                          //if (SLine.b < 0)
                {
                    Plane.Angle = 360 - Plane.Angle;
                    double MaxF = 0d, MinF = 0d, rDist = 0d;
                    double MinZ = 0d, MaxZ = 0d;
                    for (int i = 0; i < n; i++)
                    {
                        rDist = HMeasureSet.PointToPlane(lstX[i], lstY[i], lstZ[i], Plane);
                        if (i == 0)
                        {
                            MaxF = MinF = rDist;
                            MaxZ = MinZ = lstZ[i];
                        }
                        else
                        {
                            if (MaxF < rDist)
                                MaxF = rDist;
                            if (MinF > rDist)
                                MinF = rDist;

                            if (MaxZ < lstZ[i])
                                MaxZ = lstZ[i];
                            if (MinZ > lstZ[i])
                                MinZ = lstZ[i];
                        }
                    }
                    Plane.MaxFlat = MaxF;
                    Plane.MinFlat = MinF;
                    Plane.Flat = MaxF - MinF;

                    Plane.MinZ = MinZ;
                    Plane.MaxZ = MaxZ;
                }
            }
            catch (Exception ex)
            {
                //LogHandler.Instance.VTLogError(ex.ToString());
                Log.Error(ex.ToString());
            }
            return Plane;
        }
        /// <summary>
        /// 通过最小二乘法拟合直线，计算斜率k和截距b,该算法当k趋近于1时，b！=0
        /// </summary>
        /// <remarks>y位基准值，x为测量值</remarks>
        public static void CalSlopeAndIntercept(double[] x, double[] y, out double K, out double b)
        {
            try
            {
                if (x.Length == y.Length && x.Length > 1)
                {
                    int nCount = x.Length;
                    double SumX = default(double);
                    double SumY = default(double);
                    double SumXY = default(double);
                    double SumX2 = default(double);
                    double Slope = default(double);
                    double Intercept = default(double);
                    SumX = 0;
                    SumX2 = 0;
                    for (int i = 0; i <= nCount - 1; i++)
                    {
                        SumX += System.Convert.ToDouble(x[i]); //横坐标的和
                        SumX2 += x[i] * x[i]; //横坐标的平方的和
                    }

                    SumY = 0;
                    for (int i = 0; i <= nCount - 1; i++)
                    {
                        SumY += System.Convert.ToDouble(y[i]); //纵坐标的和
                    }

                    SumXY = 0;
                    for (int i = 0; i <= nCount - 1; i++)
                    {
                        SumXY += x[i] * y[i]; //横坐标乘以纵坐标的积的和
                    }

                    Intercept = System.Convert.ToDouble((SumX2 * SumY - SumX * SumXY) / (nCount * SumX2 - SumX * SumX)); //截距
                    Slope = System.Convert.ToDouble((nCount * SumXY - SumX * SumY) / (nCount * SumX2 - SumX * SumX)); //斜率

                    K = Slope;
                    b = Intercept;
                }
                else
                {
                    K = 1;
                    b = 0;
                }
            }
            catch (Exception ex)
            {
                K = 1; b = 0;
                Debug.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// /使用halcon的拟合直线算法,比fitLine更准确,因为有其自己的剔除异常点算法
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="line"></param>
        /// <returns>结果直线</returns>
        public static bool FitLine(List<double> rows, List<double> cols, out ROILine line)
        {
            line = new ROILine();
            try
            {
                HMeasureSet.SortPairs(ref rows, ref cols);
                HXLDCont lineXLD = new HXLDCont(new HTuple(rows.ToArray()), new HTuple(cols.ToArray()));
                lineXLD.FitLineContourXld("tukey", -1, 0, 5, 2, out double rowBegin, out double colBegin, out double rowEnd, out double colEnd, out double nr, out double nc, out double dist);//tukey剔除算法为halcon推荐算法
                line = new ROILine(Math.Round(rowBegin, 4), Math.Round(colBegin, 4), Math.Round(rowEnd, 4), Math.Round(colEnd, 4));
                return true;
            }
            catch (Exception)
            {
                line.Status = false;
                return false;
            }
        }
        public static bool FitLine(double X1, double Y1, double X2, double Y2, out ROILine line)
        {
            List<double> rows = new List<double> { X1, X2 };
            List<double> cols = new List<double> { Y1, Y2 };
            line = new ROILine();
            try
            {
                HMeasureSet.SortPairs(ref rows, ref cols);
                HXLDCont lineXLD = new HXLDCont(new HTuple(rows.ToArray()), new HTuple(cols.ToArray()));
                //tukey剔除算法为halcon推荐算法
                lineXLD.FitLineContourXld("tukey", -1, 0, 5, 2, out double rowBegin, out double colBegin, out double rowEnd, out double colEnd, out double nr, out double nc, out double dist);
                line = new ROILine(rowBegin, colBegin, rowEnd, colEnd);
                line.Phi = nc;
                line.Dist = dist;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 最小二乘法直线拟合
        /// </summary>
        /// <param name="xv">x点序列</param>
        /// <param name="zv">y点序列</param>
        /// <param name="num">个数</param>
        /// <param name="k">斜率</param>
        /// <param name="b">b</param>
        /// <returns></returns>
        public static bool FitLine(double[] xv, double[] zv, int num, out double k, out double b)
        {
            if (num < 3)
            {
                k = 0; b = 0;
                return false;
            }
            double A = 0.0;
            double B = 0.0;
            double C = 0.0;
            double D = 0.0;


            for (int i = 0; i < num; i++)
            {
                //ss.Format("i = %d,num = %d, %0.3f,%0.3f",i,num,xv[i],zv[i]);
                //AfxMessageBox(ss);
                A += (xv[i] * xv[i]);
                B += xv[i];
                C += (zv[i] * xv[i]);
                D += zv[i];
            }

            double tmp = 0;
            tmp = (A * num - B * B);

            if (Math.Abs(tmp) > 0.000001)
            {
                k = (C * num - B * D) / tmp;
                b = (A * D - C * B) / tmp;
            }
            else
            {
                k = 1;
                b = 0;
            }
            return true;
        }
        /// <summary>
        /// 最小二乘法圆拟合
        /// </summary>
        /// <param name="rows">点云 行坐标</param>
        /// <param name="cols">点云 列坐标</param>
        /// <param name="circle">返回圆</param>
        /// <returns>是否拟合成功</returns>
        public static bool FitCircle(double[] rows, double[] cols, out Circle_INFO circle)
        {
            circle = new Circle_INFO();
            if (cols.Length < 3)
            {
                return false;
            }
            //本地代码验证通过------20180827 yoga
            ////原始托管代码
            double sum_x = 0.0f, sum_y = 0.0f;
            double sum_x2 = 0.0f, sum_y2 = 0.0f;
            double sum_x3 = 0.0f, sum_y3 = 0.0f;
            double sum_xy = 0.0f, sum_x1y2 = 0.0f, sum_x2y1 = 0.0f;

            int N = cols.Length;
            for (int i = 0; i < N; i++)
            {
                double x = rows[i];
                double y = cols[i];
                double x2 = x * x;
                double y2 = y * y;
                sum_x += x;
                sum_y += y;
                sum_x2 += x2;
                sum_y2 += y2;
                sum_x3 += x2 * x;
                sum_y3 += y2 * y;
                sum_xy += x * y;
                sum_x1y2 += x * y2;
                sum_x2y1 += x2 * y;
            }

            double C, D, E, G, H;
            double a, b, c;

            C = N * sum_x2 - sum_x * sum_x;
            D = N * sum_xy - sum_x * sum_y;
            E = N * sum_x3 + N * sum_x1y2 - (sum_x2 + sum_y2) * sum_x;
            G = N * sum_y2 - sum_y * sum_y;
            H = N * sum_x2y1 + N * sum_y3 - (sum_x2 + sum_y2) * sum_y;
            a = (H * D - E * G) / (C * G - D * D);
            b = (H * C - E * D) / (D * D - G * C);
            c = -(a * sum_x + b * sum_y + sum_x2 + sum_y2) / N;
            circle.CenterY = Math.Round(a / (-2), 4);
            circle.CenterX = Math.Round(b / (-2), 4);
            circle.Radius = Math.Round(Math.Sqrt(a * a + b * b - 4 * c) / 2, 4);
            return true;
        }

        /// <summary>
        /// 最小二乘法圆拟合
        /// </summary>
        /// <param name="rows">点云 行坐标</param>
        /// <param name="cols">点云 列坐标</param>
        /// <param name="circle">返回圆</param>
        /// <returns>是否拟合成功</returns>
        public static bool FitCircle1(List<double> rows, List<double> cols, out ROICircle circle)
        {
            circle = new ROICircle();
            if (cols.Count < 3)
            {
                circle.Status = false;
                return false;
            }
            //本地代码验证通过------20180827 yoga
            ////原始托管代码
            double sum_x = 0.0f, sum_y = 0.0f;
            double sum_x2 = 0.0f, sum_y2 = 0.0f;
            double sum_x3 = 0.0f, sum_y3 = 0.0f;
            double sum_xy = 0.0f, sum_x1y2 = 0.0f, sum_x2y1 = 0.0f;

            int N = cols.Count;
            for (int i = 0; i < N; i++)
            {
                double x = rows[i];
                double y = cols[i];
                double x2 = x * x;
                double y2 = y * y;
                sum_x += x;
                sum_y += y;
                sum_x2 += x2;
                sum_y2 += y2;
                sum_x3 += x2 * x;
                sum_y3 += y2 * y;
                sum_xy += x * y;
                sum_x1y2 += x * y2;
                sum_x2y1 += x2 * y;
            }

            double C, D, E, G, H;
            double a, b, c;

            C = N * sum_x2 - sum_x * sum_x;
            D = N * sum_xy - sum_x * sum_y;
            E = N * sum_x3 + N * sum_x1y2 - (sum_x2 + sum_y2) * sum_x;
            G = N * sum_y2 - sum_y * sum_y;
            H = N * sum_x2y1 + N * sum_y3 - (sum_x2 + sum_y2) * sum_y;
            a = (H * D - E * G) / (C * G - D * D);
            b = (H * C - E * D) / (D * D - G * C);
            c = -(a * sum_x + b * sum_y + sum_x2 + sum_y2) / N;
            circle.CenterY = Math.Round(a / (-2), 4);
            circle.CenterX = Math.Round(b / (-2), 4);
            circle.Radius = Math.Round(Math.Sqrt(a * a + b * b - 4 * c) / 2, 4);
            return true;
        }


        /// <summary>
        /// refer: https://github.com/amlozano1/circle_fit/blob/master/circle_fit.py
        ///     # Run algorithm 1 in "Finding the circle that best fits a set of points" (2007) by L Maisonbobe, found at
        ///     # http://www.spaceroots.org/documents/circle/circle-fitting.pdf
        /// </summary>
        /// <param name="pts">A list of points</param>
        /// <param name="epsilon">A floating point value, if abs(delta) between a set of three points is less than this value, the set will
        /// be considered aligned and be omitted from the fit</param>
        /// <returns></returns>
        public static PointF FitCenter(List<PointF> pts, double epsilon = 0.1)
        {
            double totalX = 0, totalY = 0;
            int setCount = 0;
            for (int i = 0; i < pts.Count; i++)
            {
                for (int j = 1; j < pts.Count; j++)
                {
                    for (int k = 2; k < pts.Count; k++)
                    {
                        double delta = (pts[k].X - pts[j].X) * (pts[j].Y - pts[i].Y) - (pts[j].X - pts[i].X) * (pts[k].Y - pts[j].Y);
                        if (Math.Abs(delta) > epsilon)
                        {
                            double ii = Math.Pow(pts[i].X, 2) + Math.Pow(pts[i].Y, 2);
                            double jj = Math.Pow(pts[j].X, 2) + Math.Pow(pts[j].Y, 2);
                            double kk = Math.Pow(pts[k].X, 2) + Math.Pow(pts[k].Y, 2);
                            double cx = ((pts[k].Y - pts[j].Y) * ii + (pts[i].Y - pts[k].Y) * jj + (pts[j].Y - pts[i].Y) * kk) / (2 * delta);
                            double cy = -((pts[k].X - pts[j].X) * ii + (pts[i].X - pts[k].X) * jj + (pts[j].X - pts[i].X) * kk) / (2 * delta);
                            totalX += cx;
                            totalY += cy;
                            setCount++;
                        }
                    }
                }
            }
            if (setCount == 0)
            {
                //failed
                return PointF.Empty;
            }
            return new PointF((float)totalX / setCount, (float)totalY / setCount);
        }
    }

    /// <summary>标定计算</summary>
    public class Cal
    {
        /// <summary>
        /// 设置原点
        /// </summary>
        /// <param name="x">x坐标</param>
        /// <param name="y">y坐标</param>
        /// <param name="Phi">跟现有坐标弧度角</param>
        /// <returns></returns>
        public static HHomMat2D RstHomMat2D(double x, double y, double Phi)
        {
            HHomMat2D hom = new HHomMat2D();
            //本地代码验证通过------20180827 yoga
            try
            {
                hom = hom.HomMat2dRotateLocal(-Phi);
                hom = hom.HomMat2dTranslateLocal(-x, -y);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            //HTuple homTmp;
            //Wrapper.Fun.setOrig(x, y, Phi, out homTmp);
            //hom = new HHomMat2D(homTmp);
            return hom;
        }
        /// <summary>
        /// 转换坐标点(世界坐标)
        /// </summary>
        /// <param name="hom">变换矩阵</param>
        /// <param name="lstX">输入Xlist</param>
        /// <param name="lstY">输入Ylist</param>
        /// <param name="outX">输出XList</param>
        /// <param name="outY">输出YList</param>
        public static void HomAffineTransPoints(HHomMat2D hom, List<double> lstX, List<double> lstY, out List<double> outX, out List<double> outY)
        {
            outX = new List<double>();
            outY = new List<double>();
            try
            {
                HTuple x = new HTuple();
                HTuple y = new HTuple();
                x = hom.AffineTransPoint2d(new HTuple(lstX.ToArray()), new HTuple(lstY.ToArray()), out y);
                outX = x.ToDArr().ToList();
                outY = y.ToDArr().ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        /// <summary>
        /// 像素坐标转换为机械坐标和角度
        /// </summary>
        /// <param name="X">像素坐标x</param>
        /// <param name="Y">像素坐标y</param>
        /// <param name="Phi">像素坐标角度</param>
        /// <param name="hom9Calib">九点标定矩阵</param>
        /// <param name="homRoteCalib">选择中心标定矩阵</param>
        /// <param name="outX">输出机械坐标X</param>
        /// <param name="outY">输出机械坐标Y</param>
        /// <param name="outPhi">输出机械坐标角度</param>
        public static void Pixel2MachineCoord(double X, double Y, double Phi, HHomMat2D hom9Calib, HHomMat2D homRoteCalib, out double outX, out double outY, out double outPhi)
        {
            outX = 0f;
            outY = 0f;
            outPhi = 0f;
            try
            {
                HTuple pointAndPhi = new HTuple(X, Y, Phi);
                //本地代码验证通过------20180827 yoga
                //原始托管代码
                double tmpX, tmpY, tmpPhi;
                tmpX = hom9Calib.AffineTransPoint2d(X, Y, out tmpY);//图像坐标转换为世界坐标
                HHomMat2D hom = homRoteCalib.HomMat2dInvert();//反转变成世界坐标到机械坐标的转换
                outX = hom.AffineTransPoint2d(tmpX, tmpY, out outY);//世界坐标系到机械坐标系转换
                double sx, sy, angle, theta, tx, ty;
                sx = hom9Calib.HomMat2dToAffinePar(out sy, out angle, out theta, out tx, out ty);
                outPhi = angle + Phi;
            }
            catch (Exception ex)
            { Log.Error(ex.ToString()); }

        }
        /// <summary>
        /// 像素坐标转换为世界坐标和角度
        /// </summary>
        /// <param name="X">像素坐标x</param>
        /// <param name="Y">像素坐标y</param>
        /// <param name="Phi">像素坐标角度</param>
        /// <param name="hom9Calib">九点标定矩阵</param>
        /// <param name="outX">输出机械坐标X</param>
        /// <param name="outY">输出机械坐标Y</param>
        /// <param name="outPhi">输出机械坐标角度</param>
        public static void Pixel2WorldCoord(double X, double Y, double Phi, HHomMat2D hom9Calib, out double outX, out double outY, out double outPhi)
        {
            outX = 0f;
            outY = 0f;
            outPhi = 0f;
            try
            {
                //本地代码验证通过------20180827 yoga
                //原始托管代码
                outX = hom9Calib.AffineTransPoint2d(X, Y, out outY);//图像坐标转换为世界坐标
                double sx, sy, angle, theta, tx, ty;
                sx = hom9Calib.HomMat2dToAffinePar(out sy, out angle, out theta, out tx, out ty);
                outPhi = angle + Phi;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }
        /// <summary>
        /// 从当前像素坐标到目标像素坐标需要的转换
        /// </summary>
        /// <param name="fromX">当前世界坐标x</param>
        /// <param name="fromY">当前世界坐标y</param>
        /// <param name="fromPhi">当前世界坐标Phi</param>
        /// <param name="RoteCenterX">世界坐标旋转中心X</param>
        /// <param name="RoteCenterY">世界坐标旋转中心Y</param>
        /// <param name="aimX">目标世界坐标x</param>
        /// <param name="aimY">目标世界坐标y</param>
        /// <param name="aimPhi">目标世界坐标phi</param>
        /// <param name="offsetX">纠偏机械坐标offsetX</param>
        /// <param name="offsetY">纠偏机械坐标offsetY</param>
        /// <param name="offsetPhi">纠偏机械坐标offsetPhi</param>
        public static void CalCorrectionOffset(double fromX, double fromY, double fromPhi, double RoteCenterX, double RoteCenterY, double aimX, double aimY, double aimPhi, out double offsetX, out double offsetY, out double offsetPhi)
        {
            offsetX = 0f;
            offsetY = 0f;
            offsetPhi = 0f;
            try
            {
                //角度差
                offsetPhi = aimPhi - fromPhi;//弧度
                                             //根据旋转中心 旋转
                HHomMat2D hom_旋转中心旋转 = new HHomMat2D();
                hom_旋转中心旋转 = hom_旋转中心旋转.HomMat2dRotate(offsetPhi, RoteCenterX, RoteCenterY);
                double new_x;
                double new_y;
                new_x = hom_旋转中心旋转.AffineTransPoint2d(fromX, fromY, out new_y);

                //计算xy最终偏移
                offsetX = aimX - new_x;
                offsetY = aimY - new_y;

            }
            catch (Exception ex)
            { Log.Error(ex.ToString()); }
        }
        /// <summary>
        /// 对点应用任意加法 2D 变换
        /// </summary>
        public static void Affine2d(HTuple HomMat2D, double x0, double y0, out double X0, out double Y0)
        {
            HHomMat2D TempHomMat2D = new HHomMat2D(HomMat2D);
            Y0 = TempHomMat2D.AffineTransPoint2d(y0, x0, out X0);
        }
        /// <summary>
        /// 对点应用任意加法 2D 变换
        /// </summary>
        public static void Affine2d(HTuple HomMat2D, double x0, double y0, double x1, double y1, out double X0, out double Y0, out double X1, out double Y1)
        {
            HHomMat2D TempHomMat2D = new HHomMat2D(HomMat2D);
            Y0 = TempHomMat2D.AffineTransPoint2d(y0, x0, out X0);
            Y1 = TempHomMat2D.AffineTransPoint2d(y1, x1, out X1);
        }
    }


}