namespace ROB5_MES_System
{
    public partial class OrderForm : Form
    {

        private Order _assignedOrder;
        public OrderForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load the order form with the given order
        /// </summary>
        /// <param name="order"></param>
        public void LoadOrderForm(Order order)
        {
            _assignedOrder = order;
            UpdateOrderForm();
        }

        /// <summary>
        /// Update the order form
        /// </summary>
        public void UpdateOrderForm()
        {
            if (InvokeRequired)
            {
                Invoke((Action)UpdateOrderForm);
                return;
            }

            // update all data fields
            this.Text = "Order " + _assignedOrder.OrderNumber;
            OrderNumberDispLabel.Text = _assignedOrder.OrderNumber.ToString();
            CustomerDispLabel.Text = _assignedOrder.OrderCustomer;
            MedicineDispLabel.Text = _assignedOrder.MedicineType;
            ActualStartDispLabel.Text = _assignedOrder.OrderStartTime.HasValue ? _assignedOrder.OrderStartTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "N/A";
            ActualEndDispLabel.Text = _assignedOrder.OrderEndTime.HasValue ? _assignedOrder.OrderEndTime.Value.ToString("yyyy/MM/dd HH:mm:ss") : "N/A";
            OrderStateDispLabel.Text = _assignedOrder.OrderState.ToString();
            ContainerAmountDispLabel.Text = _assignedOrder.ContainerAmount.ToString();
            ContainerTypeDispLabel.Text = _assignedOrder.ContainerType.ToString();
            ProductAmountDispLabel.Text = _assignedOrder.ProductsTotal.ToString();


            // clear the tree view
            ProductTreeView.Nodes.Clear();

            // first loop through all products in the order that are not in production and have not finished production
            foreach (var product in _assignedOrder.ProductsInOrderList)
            {
                TreeNode productNode = new TreeNode();
                String productNodeString = "Product ID: " + product.ProductID + " | Amount: " + product.ContainerAmount + " | State: " + product.ProductState;
                productNode.Text = productNodeString;

                productNode = AddProcessesToProductNode(product, productNode);

                ProductTreeView.Nodes.Add(productNode);
            }

            // then loop through all products in the order that are in production or have finished production
            foreach (var product in _assignedOrder.ProductsInProductionList)
            {
                TreeNode productNode = new TreeNode();
                String productNodeString = "Product ID: " + product.ProductID + " | Amount: " + product.ContainerAmount + " | State: " + product.ProductState;

                // change the background color of the nodes based on the state of the product
                // and add start or end times if the product has started or finished production
                if (product.ProductState == OrderState.DONE)
                {
                    productNodeString += " | Start: " + product.ProductStartTime.ToString("yyyy/MM/dd hh:mm:ss") + " | End: " + product.ProductEndTime.ToString("yyyy/MM/dd hh:mm:ss");
                    productNode.BackColor = Color.FromArgb(255, 128, 128, 255);
                }
                else if (product.ProductState == OrderState.BUSY)
                {
                    productNodeString += " | Start: " + product.ProductStartTime.ToString("yyyy/MM/dd hh:mm:ss");
                    productNode.BackColor = Color.FromArgb(255, 255, 255, 128);
                    productNode.Expand();
                }

                productNode.Text = productNodeString;

                productNode = AddProcessesToProductNode(product, productNode);

                ProductTreeView.Nodes.Add(productNode);
            }
        }

        /// <summary>
        /// Add processs to the given product and its associated product tree node
        /// </summary>
        /// <param name="product"></param>
        /// <param name="productNode"></param>
        /// <returns></returns>
        private TreeNode AddProcessesToProductNode(Product product, TreeNode productNode)
        {
            foreach (var process in product.ProductCompletedProcesses)
            {
                String processNodeString = "Process ID: " + process.ProcessID.ToString() + " | Process: " + process.ProcessName + " | State: " + process.ProcessState.ToString() + " | Start: " + process.ProcessStartTime + " | End: " + process.ProcessEndTime;

                TreeNode processNode = new TreeNode(processNodeString);

                processNode.BackColor = Color.FromArgb(255, 128, 128, 255);

                productNode.Nodes.Add(processNode);
            }

            foreach (var process in product.ProductProcessQueue)
            {
                String processNodeString = "Process ID: " + process.ProcessID.ToString() + " | Process: " + process.ProcessName + " | State: " + process.ProcessState.ToString();

                TreeNode processNode = new TreeNode(processNodeString);

                productNode.Nodes.Add(processNode);
            }

            return productNode;
        }
    }
}
