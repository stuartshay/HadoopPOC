package com.sixeyed.hadoopdotnet;

import java.io.IOException;
import java.util.*;

import org.apache.hadoop.fs.Path;
import org.apache.hadoop.conf.*;
import org.apache.hadoop.io.*;
import org.apache.hadoop.mapreduce.*;
import org.apache.hadoop.mapreduce.lib.input.FileInputFormat;
import org.apache.hadoop.mapreduce.lib.input.TextInputFormat;
import org.apache.hadoop.mapreduce.lib.output.FileOutputFormat;
import org.apache.hadoop.mapreduce.lib.output.TextOutputFormat;

import au.com.bytecode.opencsv.CSVParser;

public class AreaClassification {

   public static class ClassificationMapper extends Mapper<LongWritable, Text, Text, IntWritable> {
       
      private final static IntWritable one = new IntWritable(1);      
      private final static int CLASSIFICATION_FIELD_INDEX = 29;
      private Text word = new Text();
      private CSVParser parser = new CSVParser();

      public void map(LongWritable key, Text value, Context context) throws IOException, InterruptedException {
         String line = value.toString();
         String[] fields= parser.parseLineMulti(line);  
         if (fields.length >= CLASSIFICATION_FIELD_INDEX) {
                word.set(fields[CLASSIFICATION_FIELD_INDEX]);
                context.write(word, one);
         }
      }
   }   

   public static class ClassificationReducer extends Reducer<Text, IntWritable, Text, IntWritable> {

      public void reduce(Text key, Iterable<IntWritable> values, Context context)
         throws IOException, InterruptedException {
         int sum = 0;
         for (IntWritable val : values) {
            sum += val.get();
         }
         context.write(key, new IntWritable(sum));
      }
   }

   public static void main(String[] args) throws Exception {
       
      Configuration conf = new Configuration();
      Job job = new Job(conf, "areaclassification");

      job.setJarByClass(AreaClassification.class);
      job.setOutputKeyClass(Text.class);
      job.setOutputValueClass(IntWritable.class);

      job.setMapperClass(ClassificationMapper.class);
      job.setReducerClass(ClassificationReducer.class);

      job.setInputFormatClass(TextInputFormat.class);
      job.setOutputFormatClass(TextOutputFormat.class);

      FileInputFormat.addInputPath(job, new Path(args[0]));
      FileOutputFormat.setOutputPath(job, new Path(args[1]));

      job.waitForCompletion(true);
   }
}