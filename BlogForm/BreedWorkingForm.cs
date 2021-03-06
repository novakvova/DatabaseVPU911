﻿using BlogForm.Entities;
using BlogForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BlogForm
{
    public partial class BreedWorkingForm : Form
    {
        private readonly EFContext _context;
        public BreedWorkingForm(EFContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void BreedWorkingForm_Load(object sender, EventArgs e)
        {
            var list = _context.Breeds
                .Where(x=>x.ParentId==null)
                .Select(x=>new BreedVM
            {
                Id=x.Id,
                Name=x.Name,
                Image=x.Image,
                UrlSlug=x.UrlSlug
            }).ToList();
            foreach(var item in list)
            {
                AddParent(item);
            }
            tvBreed.Focus();
        }

        private void AddParent(BreedVM breed)
        {
            TreeNode node = new TreeNode();
            node.Text = breed.Name;
            node.Name = breed.Id.ToString();
            node.Tag = breed;
            node.Nodes.Add("");
            tvBreed.Nodes.Add(node);
            
        }
        private void AddChild(TreeNode parent, BreedVM breed)
        {
            TreeNode node = new TreeNode();
            node.Text = breed.Name;
            node.Name = breed.Id.ToString();
            node.Tag = breed;
            node.Nodes.Add("");
            parent.Nodes.Add(node);
        }

        private void tvBreed_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if(e.Node.Nodes[0].Text=="")
            {
                var parent = e.Node;
                var parentId = (parent.Tag as BreedVM).Id;
                parent.Nodes.Clear();
                var list = _context.Breeds
                .Where(x => x.ParentId == parentId)
                .Select(x => new BreedVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    UrlSlug = x.UrlSlug
                }).ToList();

                foreach (var item in list)
                {
                    AddChild(parent, item);
                }
                MessageBox.Show(parentId.ToString());
            }
        }
    }
}
